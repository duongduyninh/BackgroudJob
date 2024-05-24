namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class Ccm
    {
        public string CcmId { get; set; }
        public int Mileage { get; set; }
        public DateTime Timestamp { get; set; }
        public int Priority { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
    }
}