namespace ELSAPI.Entities.OrderAggregate
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}