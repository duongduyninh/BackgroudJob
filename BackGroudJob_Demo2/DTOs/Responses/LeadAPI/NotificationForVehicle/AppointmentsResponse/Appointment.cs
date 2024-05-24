namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse
{
    public class Appointment
    {
        public DateTime PlannedTime { get; set; }
        public string Dealer { get; set; }
        public List<CbsEvent> CbsEvents { get; set; }
        public List<TireEvent> TireEvents { get; set; }
        public List<CcmEvent> CcmEvents { get; set; }
        public List<ServiceEvent> ServiceEvents { get; set; }
    }
}