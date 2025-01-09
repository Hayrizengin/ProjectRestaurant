using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Business.Concrete;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.Context;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.DataManagement;
using ProjectRestaurant.Tools.Security;
using ProjectRestaurant.Tools.Validation;
using FluentValidation.AspNetCore;
using ProjectRestaurant.Business.Validator.LoginValidation;
using ProjectRestaurant.API.Middleware;

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
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<ITokenService, TokenManager>();
builder.Services.AddScoped<IGenericValidator, FluentValidator>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IBannerService,BannerManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IFoodCategoryService,FoodCategoryManager>();
builder.Services.AddScoped<IFoodService, FoodManager>();
builder.Services.AddScoped<IMessageService,MessageManager>();
builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
builder.Services.AddScoped<ISpecialRecipeService, SpecialRecipeManager>();

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");

app.UseGlobalExceptionHandlerMiddleware();

//UserRegisterValidator'içinde userService null geliyordu bu service'in null gelmemesini saðladý.
UserRegisterValidator.Initialize(app.Services.CreateScope().ServiceProvider
                .GetRequiredService<IUserService>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseApiAuthorizationMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
