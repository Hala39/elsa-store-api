using ELSAPI.Entities.OrderAggregate;

namespace ELSAPI.Dto
{
    public class AddressDto
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public District District { get; set; }
        public Governorate Governorate { get; set; }
        
    }
}