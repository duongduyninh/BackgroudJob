using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class ServiceEvent
    {
        public string EventDemandCategoryIdentifier { get; set; }
        public string EventIdentifier { get; set; }
        public ServiceDemand ServiceDemand { get; set; }
    }
}