using System.Threading.Tasks;
using ELSAPI.Dto;
using ELSAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELSAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        public OrderController(IOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingOrders()
        {
            return Ok(await _repo.GetPendingOrders());
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentOrders()
        {
            return Ok(await _repo.GetRecentOrders());
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CreateOrderDto orderDto)
        {
            return Ok(await _repo.PlaceOrder(orderDto));
        }

        [HttpPost("confirm/{orderId}")]
        public async Task<IActionResult> ConfirmOrder(int orderId)
        {
            return Ok(await _repo.ConfirmOrder(orderId));
        }

        [HttpDelete]
        public async Task<IActionResult> ClearRecentOrders()
        {
            return Ok(await _repo.ClearRecentOrders());
        }
        
    }
}