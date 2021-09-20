using System;
using System.Collections.Generic;
using ELSAPI.Entities;

namespace ELSAPI.Dto
{
    public class CreateOrderDto
    {
        public PersonalInfoDto PersonalInfo { get; set; }
        public CreateAddressDto Address { get; set; }
        public List<BasketItem> Items { get; set; }
        public decimal Total { get; set; }
        public DateTime Starting { get; set; }
        public bool Confirmed { get; set; }
    }
}