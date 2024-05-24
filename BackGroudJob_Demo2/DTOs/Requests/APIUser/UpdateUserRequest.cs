using System.ComponentModel.DataAnnotations;

namespace BackGroudJob_Demo2.DTOs.Requests.APIUser
{
    public class UpdateUserRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
    }
}
