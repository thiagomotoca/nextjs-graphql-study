namespace GraphqlStudy.Domain.Entities;

public class Relative : Person
{
    public Guid EmployeeId { get; set; }

    [UseSorting]
    public virtual Employee Employee { get; set; }
}