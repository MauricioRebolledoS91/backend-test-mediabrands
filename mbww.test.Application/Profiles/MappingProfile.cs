using AutoMapper;
using SalesDatePrediction.test.Application.Employee.Queries.GetEmployeeList;
using SalesDatePrediction.test.Application.Order.Commands.CreateOrder;
using SalesDatePrediction.test.Application.Order.Queries.GetOrdersByCustomer;
using SalesDatePrediction.test.Application.Product.GetProductList;
using SalesDatePrediction.test.Application.Shippers.Queries.GetSshipperList;

namespace SalesDatePrediction.test.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Domain.Entities.Order, OrderListDto>();

            CreateMap<Domain.Entities.Shipper, ShipperDto>();

            CreateMap<Domain.Entities.Product, ProductDto>();

            CreateMap<Domain.Entities.Order, OrderCreationDto>().ReverseMap();

            CreateMap<Domain.Entities.Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmpId));
        }       
    }
}
