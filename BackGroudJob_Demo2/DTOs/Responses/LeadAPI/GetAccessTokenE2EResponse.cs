namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI
{
    public class GetAccessTokenE2EResponse : baseResponse
    {
        public string Access_Token { get; set; }
        public string Scope { get; set; }
        public string Bearer { get; set; }
        public int Expires_in { get; set; }
    }
}
