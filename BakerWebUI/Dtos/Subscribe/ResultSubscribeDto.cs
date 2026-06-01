namespace BakerWebUI.Dtos.Subscribe
{
    public class ResultSubscribeDto
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
