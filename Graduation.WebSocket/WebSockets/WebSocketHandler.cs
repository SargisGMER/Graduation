using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.WebSockets;
using System.Text;

namespace Graduation.WebSockets
{
    public abstract class WebSocketHandler
    {
        protected WebSocketConnectionManager WebSocketConnectionManager { get; set; }
        public WebSocketHandler(WebSocketConnectionManager webSocketConnectionManager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
            //todo
        }
        public virtual async Task OnConnected(WebSocketContent socket) { WebSocketConnectionManager.AddSocket(socket); }
        public virtual async Task OnDisconnected(WebSocketContent socket)
        {
            await WebSocketConnectionManager.RemoveSocket(WebSocketConnectionManager.GetId(socket));
        }

        public async Task SendMessageAsync(WebSocketContent socket, string message)
        {
            if (socket.WebSocket == null || socket.WebSocket.State != WebSocketState.Open)
                return;

            await socket.WebSocket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.UTF8.GetBytes(message),
                                                                          offset: 0,
                                                                          count: message.Length),
                                                                          messageType: WebSocketMessageType.Text,
                                                                          endOfMessage: true,
                                                                          cancellationToken: CancellationToken.None);
        }
        public async Task SendMessageAsync(string socketId, string message)
        {
            await SendMessageAsync(WebSocketConnectionManager.getSocketById(socketId), message);
        }
        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var item in WebSocketConnectionManager.getAll())
            {
                await SendMessageAsync(item.Value, message);
            }
        }
        public async Task ReceiveMessageAsync(WebSocketContent socket)
        {
            var receiveBuffer = new byte[1024];
            StringBuilder stringBuilderRequest = new StringBuilder();
            while (socket.WebSocket != null || socket.WebSocket.State == WebSocketState.Open)
            {
                var result = await socket.WebSocket.ReceiveAsync(buffer: new ArraySegment<byte>(receiveBuffer),
                                                       cancellationToken: CancellationToken.None);
                stringBuilderRequest.Clear();
                stringBuilderRequest.Append(Encoding.UTF8.GetString(receiveBuffer, 0, result.Count));
                //stringBuilderRequest.Append(" " + WebSocketConnectionManager.GetId(socket));
                await SendMessageToAllAsync(stringBuilderRequest.ToString());
            }
        }
        public abstract Task ReceiveAsync(WebSocketContent socket, WebSocketReceiveResult result, byte[] buffer);
    }
}
