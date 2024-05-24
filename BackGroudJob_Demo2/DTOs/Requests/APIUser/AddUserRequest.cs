using System.ComponentModel.DataAnnotations;

namespace BackGroudJob_Demo2.DTOs.Requests.APIUser
{
    public class AddUserRequest
    {
        public string? UserName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Discription { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
    }
}
