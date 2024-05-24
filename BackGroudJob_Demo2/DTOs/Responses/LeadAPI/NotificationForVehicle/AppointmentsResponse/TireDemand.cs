namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class TireDemand
    {
        public int RemainingDistance { get; set; }
        public int Counter { get; set; }
        public string Text { get; set; }
        public int? Urgency { get; set; }
    }
}