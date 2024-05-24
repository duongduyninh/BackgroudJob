namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class CurrentServiceEvent
    {
        public string EventDemandCategoryIdentifier { get; set; }
        public string EventIdentifier { get; set; }
        public ServiceDemand ServiceDemand { get; set; }
    }
}