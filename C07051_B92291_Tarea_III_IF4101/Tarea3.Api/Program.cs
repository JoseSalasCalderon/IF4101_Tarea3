using Microsoft.EntityFrameworkCore;
using Tarea3.BW.CU;
using Tarea3.BW.Interfaces.BW;
using Tarea3.BW.Interfaces.DA;
using Tarea3.DA.Acciones;
using Tarea3.DA.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Esto es necesario para que se lea la solicitud de Alexa
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<Tarea3Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Tarea3Jose")));

//Inyección de dependencias
builder.Services.AddTransient<IGestionarProductoBW, GestionarProductoBW>();
builder.Services.AddTransient<IGestionarProductoDA, GestionarProductoDA>();


var app = builder.Build();

// Configuración del middleware de CORS
app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
