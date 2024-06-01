using Microsoft.AspNetCore.Identity;

namespace RealTimeChatAppWithSignalR.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? LName { get; set; }
        public bool Status { get; set; }    //true; online , false: not online
        public string? Photo { get; set; }


        //Navigation Property
        public List<Chat> ?Chats { get; set; }
    }
}
