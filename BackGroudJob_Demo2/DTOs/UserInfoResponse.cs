﻿namespace BackGroudJob_Demo2.DTOs
{
    public class UserInfoResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<UserInfo> UserInfos { get; set; }
    }
}
