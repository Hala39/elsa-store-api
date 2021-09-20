using System.Collections.Generic;
using ELSAPI.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace ELSAPI.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        
    }
}