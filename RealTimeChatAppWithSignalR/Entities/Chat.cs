namespace RealTimeChatAppWithSignalR.Entities
{
    public class Chat
    {
     
        public string ?Id { get; set; }
        public int UserId { get; set; }
        public int ToUserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }


        //Navigation Property
        public ApplicationUser ?ApplicationUser { get; set; }
        public string ?ChatId { get; set; }
    }
}
