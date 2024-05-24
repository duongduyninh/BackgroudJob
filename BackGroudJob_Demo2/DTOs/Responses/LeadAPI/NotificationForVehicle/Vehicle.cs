namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public string CountryCode { get; set; }
        public string ShortBrand { get; set; }
        public string Model { get; set; }
        public string ModelRange { get; set; }
        public int TotalDistance { get; set; }
        public DateTime TotalDistanceTimestamp { get; set; }
        public int AverageDistance { get; set; }
        public DateTime AverageDistanceTimestamp { get; set; }
        public DateTime ProductionDate { get; set; }
        public string RegistrationDate { get; set; }
    }
}