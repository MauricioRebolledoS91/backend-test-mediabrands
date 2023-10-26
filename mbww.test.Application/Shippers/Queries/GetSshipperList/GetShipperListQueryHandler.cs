using AutoMapper;
using MediatR;
using SalesDatePrediction.test.Application.Contracts.Persistence;

namespace SalesDatePrediction.test.Application.Shippers.Queries.GetSshipperList
{
    public class GetShipperListQueryHandler: IRequestHandler<GetShipperListQuery, List<ShipperDto>>
    {
        private readonly IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Shipper> _repository;
        private readonly IMapper _mapper;

        public GetShipperListQueryHandler(IMapper mapper, IAsyncRepository<SalesDatePrediction.test.Domain.Entities.Shipper> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ShipperDto>> Handle(GetShipperListQuery request, CancellationToken cancellationToken)
        {
            var allShippers = (await _repository.ListAllAsync()).OrderBy(x => x.ShipperId);
            return _mapper.Map<List<ShipperDto>>(allShippers);
        }
    }
}
