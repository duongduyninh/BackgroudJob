namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class Bat
    {
        public string BatteryType { get; set; }
        public double WearAgeComponent { get; set; }
        public int WearLifeTimePercentage { get; set; }
        public int TravelledDistanceAtDetection { get; set; }
        public DateTime TimeStampAtDetection { get; set; }
        public int Capacity { get; set; }
        public int HealthClass { get; set; }
        public int VdaHealthClass { get; set; }
        public int CostumerHealthClass { get; set; }
        public int StartHealthClass { get; set; }
        public int StateOfChargeHealthClass { get; set; }
    }
}