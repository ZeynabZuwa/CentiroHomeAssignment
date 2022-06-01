using CentiroAssignment.Shared.RequestModels;
using CentiroAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Services.Features
{
    public interface IOrderService
    {
        Task<OrderResponse> GetOrderByOrderNo(int orderNo);
        Task<List<OrderResponse>> GetAllOrders();
        Task<OrderResponse> GetOrderById(Guid orderId);
        Task<OrderResponse> CreateOrder(OrderRequest orderRequest);
        Task<OrderResponse> UpdateOrder(OrderRequest orderRequest);
        Task<OrderResponse> DeleteOrderById(Guid orderId);
    }
}
