using ClaySmartLockSolution.Application.Handlers;
using ClaySmartLockSolution.Application.Queries;
using ClaySmartLockSolution.Core.Repositories;
using ClaySmartLockSolution.Core.Repositories.Base;
using ClaySmartLockSolution.Infrastructure.Data;
using ClaySmartLockSolution.Infrastructure.Repositories;
using ClaySmartLockSolution.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

builder.Services.AddDbContext<UserContext>(m => m.UseSqlServer(builder.Configuration.GetConnectionString("UserDB")), ServiceLifetime.Singleton);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateDoorAccessHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllUserQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetUserByIdQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AuthenticateUserQuery).GetTypeInfo().Assembly);


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDoorRepository, DoorRepository>();
builder.Services.AddTransient<IUserDoorAccessRepository, UserDoorAccessRepository>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});




var app = builder.Build();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseExceptionHandler("/error");




app.Run();


