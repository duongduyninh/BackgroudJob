using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.LeadsResponse;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.PreviousNotificationsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle
{
    public class NotificationForVehicleResponse
    {
        public string notificationId { get; set; }

        public DateTime SendTimestamp { get; set; }

        public DateTime ExtensionTimestamp { get; set; }

        public Events Events { get; set; }  

        public Vehicle Vehicle { get; set; }

        public Dealer Dealer { get; set; }

        public Customer Customer { get; set; }

        public List<PreviouNotification> previouNotifications {  get; set; }

        public List<UpcomingNotification> UpcomingNotifications{ get; set; }

        public List<Appointment> Appointments { get; set; }

        public Lead Lead { get; set; }

        public string NextToken { get; set; }

    }
}
