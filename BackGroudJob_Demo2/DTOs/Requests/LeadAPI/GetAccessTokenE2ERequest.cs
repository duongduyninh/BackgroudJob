namespace BackGroudJob_Demo2.DTOs.Requests.LeadAPI
{
    public class GetAccessTokenE2ERequest
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string scope { get; set; }
    }
}
