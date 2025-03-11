using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });
        
         modelBuilder.Entity<Person>()
            .HasOne(x => x.Department)
            .WithOne()
            .HasForeignKey<Department>(e => e.Id);

        modelBuilder.Entity<Person>()
            .HasData(
                new { Id = 1, FirstName = "Hello",  LastName = "World", DateOfBirth = DateTime.Now.AddYears(-20), DepartmentId = 1 },
                new { Id = 2, FirstName = "Theodore", LastName = "Noodle", DateOfBirth = DateTime.Now.AddYears(-3), DepartmentId = 2 }
            );
    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }
}