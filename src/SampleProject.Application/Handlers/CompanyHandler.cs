using System.Transactions;
using AutoMapper;
using MediatR;
using SampleProject.Application.Commands.Company;
using SampleProject.Application.Utils;
using SampleProject.Domain.Interfaces;
using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Domain.Models;

namespace SampleProject.Application.Handlers;

public class CompanyHandler : IRequestHandler<CreateCompanyCommand, ResponseService>,
                                IRequestHandler<UpdateCompanyCommand, ResponseService>,
                                IRequestHandler<DeleteCompanyCommand, ResponseService>
{
    private readonly IRepository<Company> _companyRepository;
    private readonly IRepository<Address> _addressRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyHandler(
        IRepository<Company> companyRepository,
        IRepository<Address> addressRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseService> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var company = _mapper.Map<Company>(command);

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _companyRepository.Create(company);
                var result = await _unitOfWork.CommitAsync();

                if (result)
                    scope.Complete();

                return new ResponseService(result);
            }
        }
        catch (Exception ex)
        {
            return new ResponseService().AddError(ex.Message);
        }
    }

    public async Task<ResponseService> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var company = await _companyRepository.GetByIdAsync(command.Id);
            if (company == null)
                throw new KeyNotFoundException("Company not found!");

            var companyUpdate = _mapper.Map(command, company)!;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _companyRepository.Update(companyUpdate);
                var result = await _unitOfWork.CommitAsync();

                if (result)
                    scope.Complete();

                return new ResponseService(result);
            }
        }
        catch (Exception ex)
        {
            return new ResponseService().AddError(ex.Message);
        }
    }

    public async Task<ResponseService> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var company = await _companyRepository.GetByIdAsync(command.Id);
            if (company == null)
                throw new KeyNotFoundException("Company not found!");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _addressRepository.Delete(company.Address);
                _companyRepository.Delete(company);
                var result = await _unitOfWork.CommitAsync();

                if (result)
                    scope.Complete();

                return new ResponseService(result);
            }
        }
        catch (Exception ex)
        {
            return new ResponseService().AddError(ex.Message);
        }
    }

}