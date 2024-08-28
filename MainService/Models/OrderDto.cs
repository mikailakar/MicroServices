namespace MainService.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
