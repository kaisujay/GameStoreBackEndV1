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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseSerilogRequestLogging();   //Serilog : Not strictly necessary. Saw 2 diff ENTRY for "CountryService" block

app.UseAuthentication();    //Added Because using Identity
app.UseAuthorization();

//app.UseMiddleware<ExceptionHandleMiddleware>();

app.MapControllers();

app.Run();
