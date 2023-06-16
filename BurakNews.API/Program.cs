using Autofac;
using Autofac.Extensions.DependencyInjection;
using BurakNews.API.Filters;
using BurakNews.API.Middlewares;
using BurakNews.API.Modules;
using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using BurakNews.Core.Services;
using BurakNews.Core.UnitOfWorks;
using BurakNews.Repository.Repositories;
using BurakNews.Repository.UnitOfWorks;
using BurakNews.Service.Mapping;
using BurakNews.Service.Services;
using BurakNews.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<NewDtoValidator>());

// Api tarafında kendi validate modelimizin aktif olması için aşağıdaki kodu kullanıyorum.
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Caching
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));



// Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),option =>
    {
        //option.MigrationsAssembly("BurakNews.Repository");
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); // Tip güvenli
    });
});


// Autofac 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UserCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
