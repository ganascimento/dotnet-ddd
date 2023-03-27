using SampleProject.Domain.Models;

namespace SampleProject.Application.Queries.EmployeeQuery;

public interface IEmployeeQuery
{
    IQueryable<Employee> GetOData();
}