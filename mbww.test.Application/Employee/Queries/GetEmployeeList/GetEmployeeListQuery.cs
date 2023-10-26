using MediatR;

namespace SalesDatePrediction.test.Application.Employee.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeDto>>
    {
    }
}
