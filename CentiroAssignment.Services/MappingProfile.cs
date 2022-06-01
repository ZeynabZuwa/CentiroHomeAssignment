using AutoMapper;
using CentiroAssignment.Shared.Models;
using CentiroAssignment.Shared.RequestModels;
using CentiroAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroAssignment.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Order
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<OrderRequest, OrderResponse>().ReverseMap();
        }
    }
}
