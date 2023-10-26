using AutoMapper;
using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;

namespace SalesDatePrediction.test.Application.Product.GetProductList
{
    public class GetProductListQueryHandler: IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Product> _repository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMapper mapper, IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _repository.ListAllAsync()).OrderBy(x => x.ProductId);
            return _mapper.Map<List<ProductDto>>(allProducts);
        }
    }
}
