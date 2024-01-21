using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get; set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>
        {
            new Categoria()
            {
                CategoriaId = Guid.Parse("4d67fc4f-3436-4140-b998-477de313808c"),
                Nombre = "Actividades Pendientes",
                Peso = 20
            },

            new Categoria()
            {
                CategoriaId = Guid.Parse("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"),
                Nombre = "Actividades Personales",
                Peso = 50
            }
        };

        modelBuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
            categoria.Property(p => p.Descripcion);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>
        {
            new Tarea()
            {
                TareaId = Guid.Parse("4d67fc4f-3436-4140-b998-477de313832c"),
                CategoriaId = Guid.Parse("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"),
                PrioridadTarea = Prioridad.Baja,
                Titulo = "Cosas personales",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            },

            new Tarea()
            {
                TareaId = Guid.Parse("4d67fc4f-3436-4140-b998-477de313833c"),
                CategoriaId = Guid.Parse("4d67fc4f-3436-4140-b998-477de313808c"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios publicos",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            }
        };

        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");

            tarea.HasKey(p => p.TareaId);

            tarea.HasOne(c => c.Categoria)
                 .WithMany(g => g.Tareas)
                 .HasForeignKey(c => c.CategoriaId);

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion);
            tarea.Property(p => p.FechaCreacion).HasColumnType("datetime");
            tarea.Property(p => p.FechaModificacion).HasColumnType("datetime");
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);

            tarea.Property(p => p.PrioridadTarea)
                 .HasConversion(
                    v => v.ToString(),
                    v => (Prioridad)Enum.Parse(typeof(Prioridad), v)
                 );
        });
    }
}