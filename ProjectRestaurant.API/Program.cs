using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Business.Concrete;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.Context;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.DataManagement;
using ProjectRestaurant.Tools.Security;
using ProjectRestaurant.Tools.Validation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ProjectRestaurantContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<ITokenService, TokenManager>();
builder.Services.AddScoped<IGenericValidator, FluentValidator>();

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
