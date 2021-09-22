using System;
using System.Collections.Generic;
using ELSAPI.Entities;
using ELSAPI.Entities.OrderAggregate;

namespace ELSAPI.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public PersonalInfoDto PersonalInfo { get; set; }
        public AddressDto Address { get; set; }
        public List<BasketItem> Items { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderedAt { get; set; }
        public bool Confirmed { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}