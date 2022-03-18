using System.ComponentModel.DataAnnotations;

namespace GraphqlStudy.Domain.Entities;

public abstract class Person
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Please specify a name for the person")]
    public string Name { get; set; }

}