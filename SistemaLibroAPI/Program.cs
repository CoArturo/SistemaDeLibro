using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection string e injeccion de contexto
//var connectionString = builder.Configuration.GetConnectionString("AppConnection");
//builder.Services.AddDbContext<P3Context>(x => x.UseSqlServer(connectionString));

//Repositorio
//Ejemplo de como injectar un repositorio:
//builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();

//Servicios
//Ejemplo de como inyectar servicio:
//builder.Services.AddScoped<IEmpresa, EmpresaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
