namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.LeadsResponse
{
    public class Lead
    {
        public string LeadKey { get; set; }
        public string LeadTypeName { get; set; }
        public string PrimarySuggestedCustomerAction { get; set;}
        public List<string> SecondarySuggestedCustomerActions { get; set; }
        public int OverallUrgency { get; set; }
    }
}