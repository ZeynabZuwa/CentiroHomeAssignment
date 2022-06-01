using CentiroAssignment.Data.Repositories.BaseRepository;
using CentiroAssignment.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Data.Repositories.OrderRepository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly CentiroAssignmentDbContext _centiroAssignmentDbContext;
        public OrderRepository(CentiroAssignmentDbContext centiroAssignmentDbContext) : base(centiroAssignmentDbContext)
        {
            _centiroAssignmentDbContext = centiroAssignmentDbContext;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _centiroAssignmentDbContext.Orders
                .ToListAsync();
        }

        public async Task<Order> GetByOrderNo(int OrderNo)
        {
            var order = await _centiroAssignmentDbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderNumber == OrderNo);

            return order;
        }
    }
}
