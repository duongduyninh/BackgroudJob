using BackGroudJob_Demo2.Data.Models;

namespace BackGroudJob_Demo2.DTOs
{
    public class GetUserResponse :baseResponse
    {
        public User UserInfos { get; set; }
    }
}
