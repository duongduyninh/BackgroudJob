using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class ServiceDemand
    {
        public int Urgency { get; set; }
        public int? Counter { get; set; }
        public int? RemainingDistance { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Text { get; set; }
        public DemandDetail? DemandDetail { get; set; }
    }
}