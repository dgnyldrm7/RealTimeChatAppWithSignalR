using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatAppWithSignalR.HubContent
{
    public interface ITypeSafeMessage
    {
        Task ReceiveSendAllMessage(string message);
    }


}
