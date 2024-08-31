using GameStoreBackEndV1.DataLogic;
using GameStoreBackEndV1.ObjectLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
