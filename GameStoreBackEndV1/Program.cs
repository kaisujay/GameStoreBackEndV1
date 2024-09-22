using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ServiceLogic.ExceptionService.ExceptionHandling;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Serilog
#region Serilog Config 1 : Config in "Program.cs" file
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.File("Logs/Sujay-log-.txt",rollingInterval:RollingInterval.Minute)
//    .CreateLogger();
#endregion

#region Serilog Config 2 : Traditional old way
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration).CreateLogger();
#endregion

#region Serilog Config 3 : Recommended way 
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
#endregion
#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(module =>
{
    module.RegisterModule<AutoFacModule>();
    //module.RegisterAssemblyModules(typeof(Program).Assembly);     // This one can also be used globally
})).ConfigureServices(services => services.AddAutofac());
#endregion

#region HttpClient
builder.Services.AddHttpClient();

//builder.Services.AddHttpClient("CountryApi", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration.GetSection("CountryApiUrl").Value);
//    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your_token");
//});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => options.Filters.Add<ExceptionHandleFilter>());

#region Memory Cache
builder.Services.AddMemoryCache();
#endregion

#region DbContext
builder.Services.AddDbContext<GameStoreDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("GameStoreDbContextConnnectionString"));
});
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion

#region CORSPolicyForAngularApp
builder.Services.AddCors(option =>
{
    /* This "AddDefaultPolicy" is a default setting from Microsoft */
    //option.AddDefaultPolicy(
    //        builder => builder
    //        .AllowAnyOrigin()         //We can also Specify the "Origin" with "WithOrigins" like - .WithOrigins("http://localhost:4200")
    //        .AllowAnyHeader());    //We can also Specify the "Header" with "WithHeader"
    //        .AllowAnyMethod()      //We can also Specify the "Method" with "WithMethod"

    /* This "AddPolicy" is a custome setting */
    option.AddPolicy("customGameStoreCors",
        builder => builder
        .WithOrigins("http://localhost:4200")       //This is the Angular App I am using
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors();  // This is for "AddDefaultPolicy"
app.UseCors("customGameStoreCors");  // This is for "Named"

//app.UseSerilogRequestLogging();   //Serilog : Not strictly necessary. Saw 2 diff ENTRY for "CountryService" block

app.UseAuthentication();    //Added Because using Identity
app.UseAuthorization();

//app.UseMiddleware<ExceptionHandleMiddleware>();

app.MapControllers();

app.Run();
