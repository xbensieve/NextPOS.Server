using AuthService.Application.DTOs;
using AuthService.Application.Queries;
using AuthService.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id)
                            ?? throw new Exception("Not found");

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
