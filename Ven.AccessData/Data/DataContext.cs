using Microsoft.EntityFrameworkCore;
using Van.Shared.Entities;

namespace Van.Shared.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Esta linea no se puede eliminar
        base.OnModelCreating(modelBuilder);

        //Validación
        modelBuilder.Entity<Country>().HasIndex(x => x.CountryName).IsUnique();

        //Para Evitar el borrado en cascada
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationShips = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys());
        foreach (var item in relationShips) {
            item.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
