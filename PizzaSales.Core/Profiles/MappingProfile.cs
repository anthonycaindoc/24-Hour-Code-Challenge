using AutoMapper;
using PizzaSales.Core.Features.Orders.Queries.GetOrderByID;
using PizzaSales.Core.Features.Orders.Queries.GetOrders;
using PizzaSales.Core.ViewModels;
using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderVM, GetOrdersVM>();
            CreateMap<OrderDetailsVM, GetOrderDetailsVM>();
            CreateMap<PizzaVM, GetOrderPizzaVM>()
                .ForMember(dest => dest.PizzaCode, opt => opt.MapFrom(src => src.Pizza.Code))
                .ForMember(dest => dest.PizzaTypeCode, opt => opt.MapFrom(src => src.PizzaType.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PizzaType.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.PizzaType.Category))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.PizzaType.Ingredients))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Pizza.Size))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Pizza.Price));

            CreateMap<OrderVM, GetOrderByIDVM>();
            CreateMap<OrderDetailsVM, GetOrderByIDOrderDetailsVM>();
            CreateMap<PizzaVM, GetOrderByIDPizzaVM>()
                .ForMember(dest => dest.PizzaCode, opt => opt.MapFrom(src => src.Pizza.Code))
                .ForMember(dest => dest.PizzaTypeCode, opt => opt.MapFrom(src => src.PizzaType.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PizzaType.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.PizzaType.Category))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.PizzaType.Ingredients))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Pizza.Size))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Pizza.Price));
        }
    }
}
