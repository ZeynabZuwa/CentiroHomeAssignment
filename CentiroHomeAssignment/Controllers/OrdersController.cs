using CentiroAssignment.Services.Features;
using CentiroAssignment.Shared.RequestModels;
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
            // TODO: Return all orders
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
        public async Task<ActionResult> ImportCSVfiles([FromBody]string filePath)
        {
            
            await _orderService.ImportCSVfiles(filePath);

            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateOtder(OrderRequest orderRequest)
        {
            // TODO: Update one specific order
            var orderResponse = await _orderService.UpdateOrder(orderRequest);
            if (orderResponse != null)
            {
                return Ok(orderResponse);
            }
            else
            {
                return BadRequest(orderResponse);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrderById(Guid orderId)
        {
            // TODO: Delete one specific order with Guid
            var orderResponses= await _orderService.DeleteOrderById(orderId);
            if (orderResponses != null)
            {
                return Ok(orderResponses);
            }
            else
            {
                return BadRequest(orderResponses);
            }
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(Guid orderId)
        {
            // TODO: Return one specific order with Guid
            var orderResponse = await _orderService.GetOrderById(orderId);
            if (orderResponse != null)
            {
                return Ok(orderResponse);
            }
            else
            {
                return BadRequest(orderResponse);
            }
        }


    }
}
