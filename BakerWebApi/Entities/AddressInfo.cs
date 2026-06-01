namespace BakerWebApi.Entities
{
    public class AddressInfo
    {
        public int AddressInfoId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
        public string MapUrl { get; set; }
    }
}
