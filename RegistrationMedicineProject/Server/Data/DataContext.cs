
namespace RegistrationMedicineProject.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Retention>().HasData(
            new Retention { Id = 1, Name = "Não" },
            new Retention { Id = 2, Name = "Sim" }
        );

        modelBuilder.Entity<RegistrationMedicine>().HasData(

            new RegistrationMedicine
            {
                Id = 1,
                Name = "Nimesulida",
                Administration = "Via Oral",
                Class = "Analgésico",
                Classification = "Tarja Vermelha",
                RetentionId = 1
            },

            new RegistrationMedicine
            {
                Id = 2,
                Name = "Azitromicina",
                Administration = "Via Oral",
                Class = "Antibiótico",
                Classification = "Tarja Vermelha",
                RetentionId = 2
            }
        );
    }

    public DbSet<RegistrationMedicine> RegistrationMedicines { get; set; }
    public DbSet<Retention> Retentions { get; set; }
}
