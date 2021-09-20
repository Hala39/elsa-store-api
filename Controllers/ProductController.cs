using System.Threading.Tasks;
using ELSAPI.Extensions;
using ELSAPI.Helpers;
using ELSAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELSAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _repo.GetProductById(id));
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts([FromQuery] ProductParams productParams)
        {
            var products = await _repo.ListProducts(productParams);
            Response.AddPaginationHeader(products.CurrentPage, products.PageSize, 
                products.TotalCount, products.TotalPages);
            return Ok(products);
        }
    }
}