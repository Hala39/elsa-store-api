using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ELSAPI.Data;
using ELSAPI.Dto;
using ELSAPI.Entities;
using ELSAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ELSAPI.Repositories
{
    public class BasketRepo : IBasketRepo
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public BasketRepo(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        string GetUserId() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<BasketItemDto> AddItemToBasket(CreateBasketItemDto item)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                var itemToAdd = new BasketItem
                {
                    AppUser = user,
                    AppUserId = user.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    PictureUrl = item.PictureUrl,
                    Quantity = item.Quantity,
                    ColorName = item.ColorName,
                    SizeName = item.SizeName
                };

                try
                {
                    await _context.BasketItems.AddAsync(itemToAdd);
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            return _mapper.Map<BasketItemDto>(itemToAdd);
        }

        public async Task<bool> UpdateBasketItem(BasketItemDto item)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            
            var itemToUpdate = await _context.BasketItems.FirstOrDefaultAsync(i => i.Id == item.Id);

            if (itemToUpdate == null ) throw new Exception("Null Data");
            
            itemToUpdate.ProductName = item.ProductName;
            itemToUpdate.Price = item.Price;
            itemToUpdate.PictureUrl = item.PictureUrl;
            itemToUpdate.Quantity = item.Quantity;
            itemToUpdate.ColorName = item.ColorName;
            itemToUpdate.SizeName = item.SizeName;

            try
            {
                _context.BasketItems.Update(itemToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
            
        public async Task<bool> RemoveItemFromBasket(int id)
        {
            var item = await _context.BasketItems.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return false;
            }

            _context.BasketItems.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<BasketItemDto>> GetBasketItemsForUser()
        {
            var items = await _context.BasketItems.Where(i => i.AppUserId == GetUserId()).ToListAsync();

            return items.Select(i => _mapper.Map<BasketItemDto>(i)).ToList();
        }

    }
}