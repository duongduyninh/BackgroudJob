namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class CbsDemand
    {
        public string ParentIdentifier { get; set; }
        public string DueDate { get; set; }
        public string RemainingDistance { get; set; }
        public int Counter { get; set; }
        public string Text { get; set; }
    }
}