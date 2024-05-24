using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class CbsEvent
    {
        public string CbsEventIdentifier { get; set; }
        public CbsDemand CbsDemand { get; set; }
    }
}