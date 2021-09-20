using System;
using System.Collections.Generic;

namespace ELSAPI.Entities.OrderAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Address Address { get; set; }
        public List<BasketItem> Items { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
        public bool Confirmed { get; set; } = false;
    }
}