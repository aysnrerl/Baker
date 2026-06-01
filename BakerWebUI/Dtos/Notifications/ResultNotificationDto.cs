namespace BakerWebUI.Dtos.Notifications
{
    public class ResultNotificationDto
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
