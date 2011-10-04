using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace nettest
{
    public class Client
    {
        Socket _socket;
        int counter = 0;
        Timer timer;
        public int attempts = 0;
        public void Connect (IAsyncResult result)
        {

        }
        public Client(IPEndPoint endPoint)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TryConnect();            
        }
        void Retry(object state)
        {            
            if (_socket.Connected == false)
            {
                ++attempts;
                TryConnect();
            }
        }
        public void TryConnect()
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse("192.168.1.17"), 8024), new AsyncCallback(Connect), _socket);
            if (timer == null)
            {
                timer = new Timer(new TimerCallback(Retry), timer, 1500, 0);
            }
            else
            {
                timer.Change(1500, 0);
            }
        }
        public void Update(GameTime gameTime)
        {
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > 50)
            {               
                if (_socket.Connected)
                {
                    DataChunk dataChunk = new DataChunk();
                    dataChunk.pos.X = 0.0f;
                    dataChunk.pos.Y = (float)gameTime.TotalGameTime.TotalMilliseconds;                      
                    _socket.Send(dataChunk.getBytes());                    
                }
                counter = 0;
            }
        }
        public void Disconnect()
        {
            if (_socket.Connected)
            {
                _socket.Send(System.Text.Encoding.ASCII.GetBytes("disconnect"));
                _socket.Disconnect(true);
            }
        }
    }
}
