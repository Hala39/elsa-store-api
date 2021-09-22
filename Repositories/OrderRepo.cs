using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ELSAPI.Data;
using ELSAPI.Dto;
using ELSAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using ELSAPI.Entities.OrderAggregate;
using ELSAPI.Entities;
using System;

namespace ELSAPI.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public OrderRepo(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        string GetUserId() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<List<OrderDto>> GetPendingOrders()
        {
            var orders = await _context.Orders.Where(o => o.UserId == GetUserId() && o.Confirmed == false)
                .Include(o => o.PersonalInfo)
                .Include(o => o.Address)
                    .ThenInclude(o => o.District)
                .Include(o => o.Address)
                    .ThenInclude(o => o.Governorate)
                .Include(o => o.Items)
                .AsNoTracking()
                .OrderByDescending(o => o.OrderedAt)
                .ToListAsync();

            return orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();
        }

        public async Task<List<OrderDto>> GetRecentOrders()
        {
            var orders = await _context.Orders.Where(o => o.UserId == GetUserId() && o.Confirmed == true)
                .Include(o => o.PersonalInfo)
                .Include(o => o.Address)
                    .ThenInclude(o => o.District)
                .Include(o => o.Address)
                    .ThenInclude(o => o.Governorate)
                .Include(o => o.Items)
                .AsNoTracking()
                .OrderByDescending(o => o.OrderedAt)
                .ToListAsync();

            return orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();
        }

        public async Task<OrderDto> PlaceOrder(CreateOrderDto orderDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            var address = new Address {
                FirstLine = orderDto.Address.FirstLine,
                SecondLine = orderDto.Address.SecondLine,
                District = await _context.Districts.FirstOrDefaultAsync(d => d.Id == orderDto.Address.DistrictId),
                Governorate = await _context.Governorates.FirstOrDefaultAsync(g => g.Id == orderDto.Address.GovernorateId)
            };

            var order = new Order {
                User = user,
                Items = orderDto.Items,
                PersonalInfo = _mapper.Map<PersonalInfo>(orderDto.PersonalInfo),
                Address = address,
                Total = orderDto.Total,
            };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> ConfirmOrder(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            order.Confirmed = true;
            order.ReceivedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearRecentOrders()
        {
            var orders = await _context.Orders.Where(o => o.UserId == GetUserId() && o.Confirmed == true)
            .Include(o => o.PersonalInfo)
                .Include(o => o.Address)
                    .ThenInclude(o => o.District)
                .Include(o => o.Address)
                    .ThenInclude(o => o.Governorate)
                .Include(o => o.Items)
                .ToListAsync();

            if (orders.Count > 0) 
            {
                foreach (var order in orders.ToList())
                {
                    _context.Orders.Remove(order); 
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteRecentOrder(int id)
        {
            var order = await _context.Orders
            .Include(o => o.PersonalInfo)
            .Include(o => o.Address)
                .ThenInclude(o => o.District)
            .Include(o => o.Address)
                .ThenInclude(o => o.Governorate)
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null) 
            {
                try
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
            return false;
            
        }
    }
}