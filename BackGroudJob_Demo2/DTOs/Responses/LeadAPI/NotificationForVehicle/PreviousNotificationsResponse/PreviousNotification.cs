namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.PreviousNotificationsResponse
{
    public class PreviousNotification
    {
        public string ChannelName { get; set; }
        public List<PreviousFeedback> PreviousFeedbacks { get; set; }
        public string? BackupFor { get; set; }
        public string Status { get; set; }
        public DateTime SendTimestamp { get; set; }
    }
}