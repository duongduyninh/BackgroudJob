using System.ComponentModel.DataAnnotations;

namespace BackGroudJob_Demo2.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Discription { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
    }
}
