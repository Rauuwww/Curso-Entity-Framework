using Curso_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Entity_Framework
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { 
                CategoriaId = Guid.Parse("97c9f346-b27c-4d0f-98ba-ae0b769604b6"), 
                Nombre="Actividades pendientes", 
                Peso=20 
            });
            categoriasInit.Add(new Categoria() { 
                CategoriaId = Guid.Parse("97c9f346-b27c-4d0f-98ba-ae0b769714b6"), 
                Nombre = "Actividades personales", 
                Peso = 50 
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);
                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() {
                TareaId = Guid.Parse("abd281ac-d1fb-4fb6-8c4e-39a82c6370ef"),
                CategoriaId = Guid.Parse("97c9f346-b27c-4d0f-98ba-ae0b769604b6"),
                PrioridadTarea = Prioridad.Media,
                titulo = "Pago de telefono fijo",
                FechaCreacion = DateTime.Now
            });

            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("abd281ac-d1fb-4fb6-8c4e-39a82c63701f"),
                CategoriaId = Guid.Parse("97c9f346-b27c-4d0f-98ba-ae0b769714b6"),
                PrioridadTarea = Prioridad.Alta,
                titulo = "Ver los cursos de Platzi",
                FechaCreacion = DateTime.Now
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareasInit);
            });

        }

    }
}
