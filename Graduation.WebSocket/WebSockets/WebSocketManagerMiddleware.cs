using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduation.WebSockets
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate next;
        private WebSocketHandler WebSocketHandler { get; set; }
        public WebSocketManagerMiddleware(RequestDelegate nextReq, WebSocketHandler webSocketHandler) { next = nextReq; WebSocketHandler = webSocketHandler; }

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await next.Invoke(context);
                return;
            }
            while (true)
            {
                var webSocketContent = new WebSocketContent(await context.WebSockets.AcceptWebSocketAsync(subProtocol: null));
                try
                {
                    await WebSocketHandler.OnConnected(webSocketContent).ConfigureAwait(false);
                    await WebSocketHandler.ReceiveMessageAsync(webSocketContent);
                }
                catch (Exception)
                {

                    if (webSocketContent.WebSocket != null)
                        await WebSocketHandler.OnDisconnected(webSocketContent);
                }
            }
        }
    }
}
