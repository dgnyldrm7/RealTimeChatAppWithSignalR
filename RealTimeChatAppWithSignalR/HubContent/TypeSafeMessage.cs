using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatAppWithSignalR.HubContent
{
    public class TypeSafeMessage : Hub<ITypeSafeMessage>
    {

        public async Task HerkeseMesagge(string message)
        {
            await Clients.All.ReceiveSendAllMessage(message);
        }

    }
}
