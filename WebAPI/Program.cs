using Application.Logic.CategoryService;
using Application.Logic.ProductService;
using Domain.Database;
using GenericRepo_Dapper.Configuration;
using Infrastructure.UnitOfWork;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string corsName = "CorsName";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, policyBuilder => policyBuilder
        .WithOrigins("http://localhost", "https://localhost")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddSingleton<ApplicationDbContext>();

builder.Services.AddRouting(context => context.LowercaseUrls = true);
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented    = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Service
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Repository
builder.Services.AddScoped<IUnit, Unit>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", info: new OpenApiInfo { Title = "Generic Repository and Dapper API", Version = "v1" });
    option.OperationFilter<HeaderFilter>();
});

var app = builder.Build();

var swaggerConfig = new SwaggerConfig();
builder.Configuration.GetSection(nameof(SwaggerConfig)).Bind(swaggerConfig);
app.UseSwagger(option => { option.RouteTemplate = swaggerConfig.JsonRoute; });
app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerConfig.UIEndpoint, swaggerConfig.Description); });

app.UseCors(corsName);

app.UseExceptionHandler("/Error");

app.MapControllers();


app.Run();

