using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.WebSockets
{
    public class LogInHandler : WebSocketHandler
    {
        public LogInHandler(WebSocketConnectionManager webSocketConnectionManager):base(webSocketConnectionManager)
        {

        }
        public override async Task ReceiveAsync(WebSocketContent socket, WebSocketReceiveResult result, byte[] buffer)
        {
            
            await SendMessageToAllAsync(Encoding.UTF8.GetString(buffer, 0, result.Count));
        }
    }
}
