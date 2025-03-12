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
                new { Id = 1, FirstName = "Hello",  LastName = "World", DepartmentId = 1, DateOfBirth = DateTime.Now.AddYears(-20), Email = "hello@world.com" },
                new { Id = 2, FirstName = "Theodore", LastName = "Noodle",  DepartmentId = 2, DateOfBirth = DateTime.Now.AddYears(-3), Email = "fake@email.com" },
                new { Id = 3, FirstName = "Hello",  LastName = "World", DepartmentId = 3, DateOfBirth = DateTime.Now.AddYears(-20), Email = "hello@world.com" },
                new { Id = 4, FirstName = "Theodore", LastName = "Noodle",  DepartmentId = 4, DateOfBirth = DateTime.Now.AddYears(-3), Email = "fake@email.com" },
                new { Id = 5, FirstName = "Hello",  LastName = "World", DepartmentId = 1, DateOfBirth = DateTime.Now.AddYears(-20), Email = "hello@world.com" },
                new { Id = 6, FirstName = "Theodore", LastName = "Noodle",  DepartmentId = 2, DateOfBirth = DateTime.Now.AddYears(-3), Email = "fake@email.com" }
            );
    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }
}
