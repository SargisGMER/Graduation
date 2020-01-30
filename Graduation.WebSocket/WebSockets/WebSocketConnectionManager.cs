using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;

namespace Graduation.WebSockets
{
    public class WebSocketConnectionManager
    {
        private ConcurrentDictionary<string, WebSocketContent> dicSocket = new ConcurrentDictionary<string, WebSocketContent>();

        public WebSocketContent getSocketById(string id) { return dicSocket.FirstOrDefault(x => x.Key == id).Value; }
        public ConcurrentDictionary<string, WebSocketContent> getAll() { return dicSocket; }
        public void AddSocket(WebSocketContent socket) { dicSocket.TryAdd(CreateConnectionId(), socket); }

        public async Task RemoveSocket(string id)
        {
            WebSocketContent socket;
            dicSocket.TryRemove(id, out socket);

            await socket.WebSocket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                                statusDescription: "Closed by the ConnectionManager",
                                                cancellationToken: CancellationToken.None);

            if (socket.WebSocket !=null)
            {
                socket.WebSocket.Dispose();
                socket.WebSocket = null;
            }
        }

        #region helper function

        //private
        private string CreateConnectionId() { return Guid.NewGuid().ToString(); }

        //public

        public string GetId(WebSocketContent socket) { return dicSocket.FirstOrDefault(x => x.Value == socket).Key; }
        #endregion
    }
}
