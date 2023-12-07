using Curso_Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>("Data Source=RUUU\\RUUUY; Initial Catalog=TareasDb; user id=sa; password=qwerty; TrustServerCertificate=True");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();//asegura que la DB este creado o no
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");

});

app.Run();
