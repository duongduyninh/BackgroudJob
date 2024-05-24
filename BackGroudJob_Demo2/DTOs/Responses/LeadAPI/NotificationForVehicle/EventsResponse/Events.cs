namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class Events
    {
        public List<CurrentCbsEvents> CurrentCbsEvents { get; set; }

        public List<FurtherOpenCbsEvents> FurtherOpenCbsEvents { get; set; }

        public List<UpcomingCbsEvents> UpcomingCbsEvents { get; set; }

        public List<object> FurtherOpenTireEvents { get; set; }

        public List<object> UpcomingTireEvents { get; set; }

        public List<CurrentCcmEvent> CurrentCcmEvents { get; set; }

        public List<object> FurtherOpenCcmEvents { get; set; }

        public List<object> UpcomingCcmEvents { get; set; }

        public List<CurrentServiceEvent> CurrentServiceEvents { get; set; }

        public List<object> FurtherOpenServiceEvents { get; set; }

        public List<object> UpcomingServiceEvents { get; set; }
    }
}
