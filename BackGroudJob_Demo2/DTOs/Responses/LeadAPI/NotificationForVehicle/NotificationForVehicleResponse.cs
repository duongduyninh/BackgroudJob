using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.LeadsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.PreviousNotificationsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle
{
    public class NotificationForVehicleResponse
    {
        public List<Notifications> Notifications { get; set; }

        public string NextToken { get; set; }
    }
}
