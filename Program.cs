using Curso_Entity_Framework;
using Curso_Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();//asegura que la DB este creado o no
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/v1/tareas", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/v1/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
