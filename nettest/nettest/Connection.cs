using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace nettest
{
    public class Connection
    {
        GameServer _server;
        Socket _socket;
        byte[] buffer = new byte[256];
        public String lastText = "";
        public void ReceiveData (IAsyncResult result)
        {
            String text = System.Text.Encoding.ASCII.GetString(buffer);            
            text = text.TrimEnd('\0');
            lastText = "Message from " + _socket.RemoteEndPoint + ": " + text;
            if (text == "disconnect")
            {
                Disconnect();
            }
            else
            {
                ClearBuffer();
                _socket.BeginReceive(buffer, 0, 256, SocketFlags.None, new AsyncCallback(ReceiveData), _socket);
            }
        }

        void ClearBuffer()
        {
            for (int i = 0; i < 256; ++i)
            {
                buffer[i] = 0;
            }
        }

        public Connection(GameServer server, Socket socket)
        {
            _socket = socket;
            _server = server;
            _socket.BeginReceive(buffer, 0, 256, SocketFlags.None, new AsyncCallback(ReceiveData), _socket);                        
        }
        public void Disconnect()
        {
            _socket.Disconnect(false);
            _server.End(this);
        }
    }
}
