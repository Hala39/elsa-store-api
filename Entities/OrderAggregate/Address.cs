namespace ELSAPI.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, Governorate governorate, District district, string city, string firstLine, string secondLine)
        {
            Governorate = governorate;
            District = district;
            City = city;
            FirstLine = firstLine;
            SecondLine = secondLine;
        }

        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Governorate Governorate { get; set; }
        
        public District District { get; set; }
        
        public string City { get; set; }
        
        public string FirstLine { get; set; }
        
        public string SecondLine { get; set; }
        
    }
}