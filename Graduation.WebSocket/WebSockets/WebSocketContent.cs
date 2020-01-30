using System.Net.WebSockets;

namespace Graduation
{
    public class WebSocketContent
    {
        public WebSocket WebSocket;
        public string RequestMessage{ get; set; }
        public string ResponseMessage { get; set; }
        public WebSocketContent(WebSocket socket ) { WebSocket = socket; }

    }
}
