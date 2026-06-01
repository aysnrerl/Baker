namespace BakerWebApi.Entities
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
