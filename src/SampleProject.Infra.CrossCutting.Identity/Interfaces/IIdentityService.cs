namespace SampleProject.Infra.CrossCutting.Identity.Interfaces;

public interface IIdentityService
{
    int GetUserId();
    int GetUserCompanyId();
    string GetRole();
}