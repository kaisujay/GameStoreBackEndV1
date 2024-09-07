using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameStoreBackEndV1.NuGetDependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseAuthentication();    //Added Because using Identity
app.UseAuthorization();

app.MapControllers();

app.Run();
