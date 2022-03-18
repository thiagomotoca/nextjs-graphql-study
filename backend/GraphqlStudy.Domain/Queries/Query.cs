using GraphqlStudy.Domain.Context;
using GraphqlStudy.Domain.Entities;
using HotChocolate;

namespace GraphqlStudy.Domain.Queries;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees([Service] ApplicationDbContext context) =>
        context.Employees;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Relative> GetRelatives([Service] ApplicationDbContext context) =>
        context.Relatives;
}