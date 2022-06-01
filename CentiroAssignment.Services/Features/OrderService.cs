using AutoMapper;
using CentiroAssignment.Data.Repositories.OrderRepository;
using CentiroAssignment.Shared.Models;
using CentiroAssignment.Shared.RequestModels;
using CentiroAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Services.Features
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderResponse> GetOrderByOrderNo(int orderNo)
        {
            var order = await _orderRepository.GetByOrderNo(orderNo);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderResponses = _mapper.Map<List<OrderResponse>>(orders);
            return orderResponses;
        }

        public async Task<OrderResponse> GetOrderById(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }

        public async Task<OrderResponse> CreateOrder(OrderRequest orderRequest)
        {
            var order = new Order()
            {
                OrderNumber = orderRequest.OrderNumber,
                OrderLineNumber = orderRequest.OrderLineNumber,
                ProductNumber = orderRequest.ProductNumber,
                Quantity = orderRequest.Quantity,
                Name = orderRequest.Name,
                Description = orderRequest.Description,
                Price = orderRequest.Price,
                ProductGroup = orderRequest.ProductGroup,
                OrderDate = orderRequest.OrderDate,
                CustomerName = orderRequest.CustomerName,
                CustomerNumber = orderRequest.CustomerNumber
                              
            };

            await _orderRepository.AddAsync(order);

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> UpdateOrder(OrderRequest orderRequest)
        {
            var orderFromDb = await _orderRepository.GetByIdAsync(orderRequest.OrderId);

            if (orderFromDb != null)
            {
                orderFromDb.OrderNumber = orderRequest.OrderNumber;
                orderFromDb.OrderLineNumber = orderRequest.OrderLineNumber;
                orderFromDb.ProductNumber = orderRequest.ProductNumber;
                orderFromDb.Quantity = orderRequest.Quantity;
                orderFromDb.Name = orderRequest.Name;
                orderFromDb.Description = orderRequest.Description;
                orderFromDb.Price = orderRequest.Price;
                orderFromDb.ProductGroup = orderRequest.ProductGroup;
                orderFromDb.OrderDate = orderRequest.OrderDate;
                orderFromDb.CustomerName = orderRequest.CustomerName;
                orderFromDb.CustomerNumber = orderRequest.CustomerNumber;

                await _orderRepository.UpdateAsync(orderFromDb);
            }
            return _mapper.Map<OrderResponse>(orderRequest);

        }

        public async Task<OrderResponse> DeleteOrderById(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            await _orderRepository.DeleteAsync(order);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }

    }
}
