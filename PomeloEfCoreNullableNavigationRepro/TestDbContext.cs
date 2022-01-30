using Microsoft.EntityFrameworkCore;

namespace PomeloEfCoreNullableNavigationRepro;

public class TestDbContext : DbContext
{
    public DbSet<Person> People => Set<Person>();
    public DbSet<Car> Cars => Set<Car>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "server=localhost;database=test1;User ID=root;password=Lmot5q";
        optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.LatestSupportedServerVersion);
    }
}

[Serializable]
public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public Car Car { get; set; } = null!;
}

[Serializable]
public class Car
{
    public int Id { get; set; }
    public string Maker { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
}
