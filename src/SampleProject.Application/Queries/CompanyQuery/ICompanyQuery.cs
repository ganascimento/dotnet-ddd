using SampleProject.Domain.Models;

namespace SampleProject.Application.Queries.CompanyQuery;

public interface ICompanyQuery
{
    IQueryable<Company> GetOData();
}