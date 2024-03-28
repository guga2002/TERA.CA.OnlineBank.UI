﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<UserRepository> _Logger;
        public UserRepository(WalletDb db,UserManager<User>manageusers,SignInManager<User>managesign,RoleManager<IdentityRole>rolemanager,ILogger<UserRepository> log) : base(db)
        {
            this._SignInManager = managesign;
            this._RoleManager = rolemanager;
            this._UserManager = manageusers;
            this._Logger = log;
        }

        public async Task<bool> AddRole(string role)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                var res = await Context.Roles.AnyAsync(io => io.Name == role.ToUpper());
                if (!res)
                {
                    await _RoleManager.CreateAsync(new IdentityRole(role));
                    await transact.CommitAsync();
                    _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                    return true;
                }
               await transact.RollbackAsync();
                return false;
            }
        }

        public async  Task<bool> AsignToRole(string Id, string Role)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
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
                await transact.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> Create(User entity)
        {
           await  Context.Users.AddAsync(entity);
            return true;
        }

        public async  Task<bool> Delete(User entoty)
        {
            Context.Users.Remove(entoty);
            await Context.SaveChangesAsync();
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
            _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
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
                if (Context.Users.Any(io => io.PersonalNumber == entity.PersonalNumber))
                {
                    Context.Users.Update(entity);
                    await Context.SaveChangesAsync();
                    await transact.RollbackAsync();
                    return true;
                }
                await transact.CommitAsync();
                _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                return false;
            }
        }
    }
}
