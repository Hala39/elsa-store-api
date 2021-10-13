using System.Collections.Generic;
using System.Threading.Tasks;
using ELSAPI.Dto;
using ELSAPI.Helpers;

namespace ELSAPI.Interfaces
{
    public interface IProductRepo
    {
         Task<PagedList<GetProductDto>> ListProducts(ProductParams productParams);
         Task<GetSingleProductDto> GetProductById(int id);
    }
}