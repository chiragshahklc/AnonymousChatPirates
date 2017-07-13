using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace AnonymousServer
{
    class ClientSockets
    {
        Socket _ClientSocket;
        ServerSocket _Server;
        ReceiveMethods _RM;
        byte[] _buffer;
        public string Name { get; set; }
        private bool isValidated;
        

        public ClientSockets(Socket socket, string name, ServerSocket server)
        {
            _ClientSocket = socket;
            _buffer = new byte[socket.ReceiveBufferSize];
            _RM = new ReceiveMethods();
            Name = name;
            _Server = server;
            IsValidated = false;
            BeginReceive();
        }
        public string tokenValue { get; set; }

        public bool IsValidated
        {
            get
            {
                return this.isValidated;
            }
            set
            {
                this.isValidated = value;
                if (this.isValidated)
                {
                    _Server.UpdateConnectedUsersLabel();
                    _Server.UpdateConnectedUserName(Name);
                }
            }
        }

        public int TokenRequested
        {
            set
            {
                _Server.TokenRequested(value, StaticMethods.TokensList[StaticMethods.TokensList.Count - 1].user);
            }
        }

        public string Log
        {
            set
            {
                _Server.Log(value);
            }
        }

        public string IPAddress
        {
            get
            {
                var ip = _ClientSocket.RemoteEndPoint as IPEndPoint;
                return ip.Address.ToString();
            }
        }

        public string Port
        {
            get
            {
                var ip = _ClientSocket.RemoteEndPoint as IPEndPoint;
                return ip.Port.ToString();
            }
        }

        

        private void BeginReceive()
        {
            _buffer = new byte[8192];
            _ClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.Peek, new AsyncCallback(ReceiveCallBack), _ClientSocket);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            int size = 0, rec = -1;

            var handler = (Socket)ar.AsyncState;
            rec = _ClientSocket.EndReceive(ar);

            if (rec >= 4)
            {
                rec = handler.Receive(_buffer, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(_buffer, 0);
                byte[] tmpBuff = new byte[size];
                int read = handler.Receive(tmpBuff, 0, size, SocketFlags.None);
                while (size > read)
                {
                    read += handler.Receive(tmpBuff, read, size - read, SocketFlags.None);
                }
                MemoryStream ms = tmpBuff.ToMemoryStream();
                _RM.ReadMemoryStream(ms, this);
            }

            BeginReceive();
        }

        public void SendMessage(byte[] buf)
        {
            Send(buf, 0, buf.Length);
        }
        private void Send(byte[] buff, int index, int length)
        {
            _ClientSocket.BeginSend(BitConverter.GetBytes(buff.Length), 0, 4, SocketFlags.None, new AsyncCallback(SendCallback), _ClientSocket);
            _ClientSocket.BeginSend(buff, index, length, SocketFlags.None, new AsyncCallback(SendCallback), _ClientSocket);
        }
        private void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            int sent = _ClientSocket.EndSend(ar);
        }

        public void BroadcastMsg(byte[] buffer)
        {
            _Server.BroadcastToEveryone(buffer);
        }
        public void SendMsgToServer(string msg, Usertype type)
        {
            _Server.SendMsgToServer(msg, type);
        }

    }
}
