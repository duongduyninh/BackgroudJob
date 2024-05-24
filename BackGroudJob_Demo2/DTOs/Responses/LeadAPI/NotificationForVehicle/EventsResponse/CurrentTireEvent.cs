using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class CurrentTireEvent
    {
        public string TireEventIdentifier { get; set; }
        public TireDemand TireDemand { get; set; }
    }
}