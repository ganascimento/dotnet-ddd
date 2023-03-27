using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Domain.Models;
using SampleProject.Infra.CrossCutting.Identity.Constants;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;

namespace SampleProject.Application.Queries.CompanyQuery;

public class CompanyQuery : ICompanyQuery
{
    private readonly IRepository<Company> _companyRepository;
    private readonly IIdentityService _identityService;

    public CompanyQuery(IRepository<Company> companyRepository, IIdentityService identityService)
    {
        _companyRepository = companyRepository;
        _identityService = identityService;
    }

    public IQueryable<Company> GetOData()
    {
        var role = _identityService.GetRole();
        if (role == RoleConstants.ROOT)
            return _companyRepository.GetAll();

        var companyId = _identityService.GetUserCompanyId();
        return _companyRepository
            .GetAll()
            .Where(x => x.Id == companyId);
    }
}