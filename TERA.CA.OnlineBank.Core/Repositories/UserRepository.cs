using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Security.Claims;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;
using TERA.CA.OnlineBank.Infrastructure.EmailServices;
using TERA.CA.OnlineBank.Infrastructure.Interface;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<UserRepository> _Logger;
        private readonly Ismtp sendNow;
        public UserRepository(WalletDb db,UserManager<User>manageusers,SignInManager<User>managesign,RoleManager<IdentityRole>rolemanager,ILogger<UserRepository> log) : base(db)
        {
            this._SignInManager = managesign;
            this._RoleManager = rolemanager;
            this._UserManager = manageusers;
            this._Logger = log;
            sendNow = new SmtpService();
        }

        public async Task<bool> AddRole(string role)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {


                    var res = await Context.Roles.AnyAsync(io => io.Name == role.ToUpper());
                    if (!res)
                    {
                        await _RoleManager.CreateAsync(new IdentityRole(role));
                        await transact.CommitAsync();
                        _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                        return true;
                    }
                    return false;
                }
                catch (Exception exp )
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async  Task<bool> AsignToRole(string Id, string Role)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {

                    var user = await Context.Users.Where(io => io.Id == Id).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        if (await _RoleManager.RoleExistsAsync(Role))
                        {
                            await _UserManager.AddToRoleAsync(user, Role);
                            await transact.CommitAsync();
                            _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception exp)
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> Create(User entity)
        {
            await  Context.Users.AddAsync(entity);
            sendNow.SendMesaage(entity.Email??"aapkhazava22@gmail.com", "აქაუნთ შეიქმნა", " ტერაში  შენს სახელზე გაიხსნა ახალი ანგარიში");
            return true;
        }

        public async Task<bool> ResetPasword(string id, string old, string newpasswo)
        {
            if(Context.Users.Any(io=>io.Id==id))
            {
                var res = await Context.Users.FirstOrDefaultAsync(io => io.Id == id);
                if (res != null)
                {
                    await _UserManager.ChangePasswordAsync(res, old, newpasswo);
                    sendNow.SendMesaage(res.Email ?? "aapkhazava22@gmail.com", "პაროლი შეიცვალა", "შენი პაროლი შეიცვალა წარმატებით");
                    return true;
                }
            }
            return false;
        }
        public async  Task<bool> Delete(User entoty)
        {
            Context.Users.Remove(entoty);
            await Context.SaveChangesAsync();
            sendNow.SendMesaage(entoty.Email ?? "aapkhazava22@gmail.com", "აქაუნთი წაიშალა", "მოხდა თქვენი ანგარიშის დეაქტივაცია");
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await  Context.Users.ToListAsync();
        }

        public async Task<User> GetById(string Id)
        {
            return await  Context.Users.FirstOrDefaultAsync(io => io.Id == Id)??new User();
        }

        public async Task<bool> Register(User user, string Password)
        {
           await  _UserManager.CreateAsync(user, Password);
           await _UserManager.AddToRoleAsync(user, "POWEREDUSER");
           _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
           sendNow.SendMesaage(user.Email ?? "aapkhazava22@gmail.com", "აქაუნთი შეიქმნა", $"{user.Name} გილოცავთ , თქვენს სახელზე შეიქმნა ახალი ანგარიში");
           return true;
        }

        public async Task<bool> SignIn(string UserName, string Password)
        {
            await _SignInManager.PasswordSignInAsync(UserName, Password, false, false);
            return true;
        }

        public async Task<bool> Update(User entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (Context.Users.Any(io => io.PersonalNumber == entity.PersonalNumber))
                    {
                        Context.Users.Update(entity);
                        await Context.SaveChangesAsync();
                        await transact.CommitAsync();
                        _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                        sendNow.SendMesaage(entity.Email ?? "aapkhazava22@gmail.com", "ცვლილება", $"შენი აქაუნთის დეტალები შეიცვალა , წარმატებით");
                        return true;
                    }
                    return false;
                }
                catch (Exception exp)
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async  Task<bool> Signout()
        {
            if (_SignInManager.IsSignedIn(ClaimsPrincipal.Current))
            {
                await _SignInManager.SignOutAsync();
                return true;
            }
            return false;
        }
    }
}
