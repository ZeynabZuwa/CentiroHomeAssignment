using CentiroAssignment.Data.Repositories.BaseRepository;
using CentiroAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroAssignment.Data.Repositories.OrderRepository
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
