using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Text;

namespace Graduation.WebSockets
{
    public class ChatRoomHandler : WebSocketHandler
    {
        public ChatRoomHandler(WebSocketConnectionManager webSocketConnectionManager): base(webSocketConnectionManager) { }
        public override async Task ReceiveAsync(WebSocketContent socket, WebSocketReceiveResult result, byte[] buffer)
        {
            await SendMessageToAllAsync("sgfhhj");
        }
    }
}
