using MediatR;

namespace SalesDatePrediction.test.Application.Product.GetProductList
{
    public class GetProductListQuery: IRequest<List<ProductDto>>
    {
    }
}
