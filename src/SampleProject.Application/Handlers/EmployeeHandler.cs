using System.Transactions;
using AutoMapper;
using MediatR;
using SampleProject.Application.Commands.Employee;
using SampleProject.Application.Utils;
using SampleProject.Domain.Interfaces;
using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Domain.Models;

namespace SampleProject.Application.Handlers;

public class EmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResponseService>,
                                IRequestHandler<UpdateEmployeeCommand, ResponseService>,
                                IRequestHandler<DeleteEmployeeCommand, ResponseService>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Company> _companyRepository;
    private readonly IRepository<Phone> _phoneRepository;
    private readonly IRepository<Address> _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeHandler(
        IMapper mapper,
        IRepository<Employee> employeeRepository,
        IRepository<Company> companyRepository,
        IRepository<Phone> phoneRepository,
        IRepository<Address> addressRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _phoneRepository = phoneRepository;
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseService> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var company = await _companyRepository.GetByIdAsync(command.CompanyId);
            if (company == null)
                throw new KeyNotFoundException("Company not found!");

            var employee = _mapper.Map<Employee>(command);
            employee.Company = company;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _employeeRepository.Create(employee);
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

    public async Task<ResponseService> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetByIdAsync(command.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found!");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (employee.Cellphone != null && command.Cellphone == null)
                    _phoneRepository.Delete(employee.Cellphone);

                if (employee.Telephone != null && command.Telephone == null)
                    _phoneRepository.Delete(employee.Telephone);

                var employeeUpdate = _mapper.Map(command, employee);

                _employeeRepository.Update(employeeUpdate);

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

    public async Task<ResponseService> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetByIdAsync(command.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found!");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (employee.Telephone != null) _phoneRepository.Delete(employee.Telephone);
                if (employee.Cellphone != null) _phoneRepository.Delete(employee.Cellphone);
                _addressRepository.Delete(employee.Address);
                _employeeRepository.Delete(employee);
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