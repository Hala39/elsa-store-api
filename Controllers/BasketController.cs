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
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepo _repo;
        public BasketController(IBasketRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("addToBasket")]
        public async Task<IActionResult> AddItemToBasket(CreateBasketItemDto item)
        {
            return Ok(await _repo.AddItemToBasket(item));
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems()
        {
            return Ok(await _repo.GetBasketItemsForUser());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem([FromBody] BasketItemDto item)
        {
            return Ok(await _repo.UpdateBasketItem(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            return Ok(await _repo.RemoveItemFromBasket(id));
        }

    }
}