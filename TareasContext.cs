using Curso_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Entity_Framework
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
       
    }
}
