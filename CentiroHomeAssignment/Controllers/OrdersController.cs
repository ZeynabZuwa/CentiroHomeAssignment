using CentiroAssignment.Services.Features;
using CentiroAssignment.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            // TODO: Return all products
            var orderResponses = await _orderService.GetAllOrders();
            if (orderResponses != null && orderResponses.Count > 0)
            {
                return Ok(orderResponses);
            }
            else
            {
                return BadRequest(orderResponses);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ImportCSVfiles([FromBody] string filePath)
        {
            
            await _orderService.ImportCSVfiles(filePath);

            return Ok();
        }
    }
}
