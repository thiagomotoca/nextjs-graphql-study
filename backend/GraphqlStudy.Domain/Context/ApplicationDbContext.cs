using Bogus;
using GraphqlStudy.Domain.Context.Configuration;
using GraphqlStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlStudy.Domain.Context;

public class ApplicationDbContext : DbContext
{
    private readonly Faker<Employee> fakeEmployee = new Faker<Employee>()
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(e => e.Name, f => f.Name.FullName());

    private readonly Faker<Relative> fakeRelative = new Faker<Relative>()
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(e => e.Name, f => f.Name.FullName());

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EmployeeConfiguration());
        builder.ApplyConfiguration(new RelativeConfiguration());

        var rnd = new Random();

        var employeeData = fakeEmployee.Generate(rnd.Next(2, 5));
        var relativeData = new List<Relative>();
        employeeData.ForEach(e =>
        {
            var employeeRelativeData = fakeRelative.Generate(rnd.Next(2, 5));
            employeeRelativeData.ForEach(r => r.EmployeeId = e.Id);

            relativeData.AddRange(employeeRelativeData);
        });

        builder.Entity<Employee>().HasData(employeeData);
        builder.Entity<Relative>().HasData(relativeData);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Relative> Relatives { get; set; }
}