global using Ecomerce.Data;
using Ecomerce.Data.Contexts;
using Ecomerce.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

#region ConfigureService()
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region InjeçãoDependencias

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddDbContext<EcomerceContext>(option =>
{
    option.UseSqlServer(config.GetConnectionString("Ecomerce"), b => b.MigrationsAssembly("Ecomerce.Api"));
});

#endregion

#endregion

var app = builder.Build();

#region Configure()
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
#endregion