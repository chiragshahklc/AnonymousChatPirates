using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace AnonymousChatServer
{
    public class ClientSockets
    {
        Socket _ClientSocket;
        byte[] _buffer;
        string Name;

        public ClientSockets(Socket socket, string name)
        {
            _ClientSocket = socket;
            _buffer = new byte[socket.ReceiveBufferSize];
            Name = name;
        }

        private void BeginReceive()
        {
            StateObject state = new StateObject();
            state.workSocket = _ClientSocket;
            _ClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.Peek, new AsyncCallback(ReceiveCallBack), state);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            int size = 0, rec = -1;

            var state = (StateObject)ar.AsyncState;
            var handler = state.workSocket;

            rec = handler.EndReceive(ar);
            if (rec >= 4)
            {
                rec = handler.Receive(state.buffer, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(state.buffer, 0);

                int read = handler.Receive(state.buffer, 0, size, SocketFlags.None);
                while (size > read)
                {
                    var readX = handler.Receive(state.buffer, 0, size - read, SocketFlags.None);
                    read += readX;
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, readX));
                }
            }

            BeginReceive();
        }
        public String GetName()
        {
            return Name;
        }
    }
}
