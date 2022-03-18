namespace GraphqlStudy.Domain.Entities;

public class Employee : Person
{
    [UseSorting]
    public virtual ICollection<Relative> Relatives { get; set; }
}