using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Domain.Models;
using SampleProject.Infra.CrossCutting.Identity.Constants;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;

namespace SampleProject.Application.Queries.EmployeeQuery;

public class EmployeeQuery : IEmployeeQuery
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IIdentityService _identityService;

    public EmployeeQuery(IRepository<Employee> employeeRepository, IIdentityService identityService)
    {
        _employeeRepository = employeeRepository;
        _identityService = identityService;
    }

    public IQueryable<Employee> GetOData()
    {
        var role = _identityService.GetRole();
        if (role == RoleConstants.ROOT)
            return _employeeRepository.GetAll();

        var companyId = _identityService.GetUserCompanyId();
        return _employeeRepository
            .GetAll()
            .Where(x => x.Company.Id == companyId);
    }
}