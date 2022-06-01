using CentiroAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroAssigment.UI.Data
{
    public interface IOrderDataService
    {
        Task<List<OrderResponse>> GetAllOrders();
        Task ImportOrders(string filePath);

    }
}
