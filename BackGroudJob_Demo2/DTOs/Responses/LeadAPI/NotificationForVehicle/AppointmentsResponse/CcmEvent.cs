using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class CcmEvent
    {
        public string CcmEventIdentifier { get; set; }
        public CcmDemand CcmDemand { get; set; }
    }
}