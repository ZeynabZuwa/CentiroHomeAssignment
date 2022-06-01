using CentiroAssignment.Data.Repositories.BaseRepository;
using CentiroAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Data.Repositories.OrderRepository
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetByOrderNo(int OrderNo);
    }
}
