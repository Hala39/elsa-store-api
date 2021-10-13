using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ELSAPI.Data;
using ELSAPI.Dto;
using ELSAPI.Entities;
using ELSAPI.Helpers;
using ELSAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ELSAPI.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepo(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // tested
        public async Task<GetProductDto> GetProductById(int id) 
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if (product == null)
            {
                throw new Exception("Product does not exist!");
            }

            return _mapper.Map<GetProductDto>(product);
        }

        // tested
        public async Task<PagedList<GetProductDto>> ListProducts(ProductParams productParams)
        {
            var query = _context.Products.AsQueryable();
            
            query = query.OrderBy(p => p.Date);

            if (!String.IsNullOrEmpty(productParams.SearchString))
            {
                query = query.Where(p => p.Description.ToLower().Contains(productParams.SearchString.ToLower())
                                                || p.Category.Name.ToLower().Contains(productParams.SearchString.ToLower()));
            }

            if (productParams.CategoryId != null)
            {
                query = query.Where(p => p.CategoryId == productParams.CategoryId);
            }
            
            if (productParams.SizeId != null)
            {
                query = query.Where(p => p.Colors.Any(c => c.SizeOptions.Any(s => s.SizeId == productParams.SizeId)));
            }

            if (!String.IsNullOrEmpty(productParams.OrderBy))
            {
                switch (productParams.OrderBy)
                {
                    case "price_desc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "price":
                        query = query.OrderBy(p => p.Price);
                        break;
                    default:
                        query = query.OrderByDescending(p => p.Date);
                        break;
                }
            }

            return await PagedList<GetProductDto>.CreateAsync(query.ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                .AsNoTracking(), productParams.PageNumber, productParams.PageSize);
        }

    }
}