using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;
using TERA.CA.OnlineBank.Core.Repositories;
using TERA.CA.OnlineBank.UI.Hellpers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<WalletDb>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("WalletDb"));
});

builder.Services.AddIdentity<User, IdentityRole>().
AddEntityFrameworkStores<WalletDb>().
AddDefaultTokenProviders();

var validations = builder.Configuration.GetSection("TokenValidation").Get<TokenValidationSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        if (validations != null)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {

                ValidateIssuer = validations.ValidateIssuer,
                ValidateAudience = validations.ValidateAudience,
                ValidateLifetime = validations.ValidateLifetime,
                ValidateIssuerSigningKey = validations.ValidateIssuerSigningKey,
                ValidIssuer = validations.ValidIssuer,
                ValidAudience = validations.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(validations.IssuerSigningKey?? "65E255FF-F399-42D4-9C7F-D5D08B0EC285")),
            };
        }
    });

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
builder.Services.AddScoped<ICurencyRepository, CurencyRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
