namespace BackGroudJob_Demo2.DTOs
{
    public class baseResponse
    {
        public bool? Status { get; set; }  
        public int? StatusCodeAPI { get; set; }
        public string? Message { get; set; } = string.Empty;
    }
}
