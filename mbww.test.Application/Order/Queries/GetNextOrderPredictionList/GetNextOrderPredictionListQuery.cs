using MediatR;
using SalesDatePrediction.test.Domain.Entities;

namespace SalesDatePrediction.test.Application.Order.Queries.GetNextOrderPredictionList
{
    public class GetNextOrderPredictionListQuery : IRequest<List<NextOrderPrediction>>
    {
    }
}
