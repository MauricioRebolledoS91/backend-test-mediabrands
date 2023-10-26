using AutoMapper;
using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;

namespace SalesDatePrediction.test.Application.Employee.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
    {
        private readonly IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(IMapper mapper, IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Employee> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = (await _repository.ListAllAsync()).OrderBy(x => x.FirstName);
            return _mapper.Map<List<EmployeeDto>>(allEmployees);
        }
    }
}
