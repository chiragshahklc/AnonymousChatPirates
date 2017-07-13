using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace AnonymousChatClient
{
    public enum ConnectionStatus
    {
        Failed = 0,
        Successful = 1
    }
    public class ClientSocket
    {
        Socket _Client;
        byte[] _buffer;
        ReceiveMethods _RM;
        SendMethods _SM;
        ConnectionForm confrm;
        private bool isValidated;

        public ClientSocket(ConnectionForm frm)
        {
            _Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _RM = new ReceiveMethods();
            _SM = new SendMethods();
            confrm = frm;
        }

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
                    confrm.UserValidated(true);
                }
                else
                    confrm.UserValidated(false);
            }
        }

        public void StartChat()
        {
            confrm.CanChatStart = true;
        }

        public void SetChatUsers(List<string> users)
        {
            confrm.ChatUsers(users);
        }

        public void SetChatToken(string token)
        {
            confrm.ReceiveChatToken(token);
        }
        public void MsgReceived(string msg, Usertype type)
        {
            confrm.ReceiveMsg(msg, type);
        }

        public void ConnectToServer(IPAddress ipa)
        {
            _Client.BeginConnect(new IPEndPoint(ipa, 9192), new AsyncCallback(ConnectCallback), _Client);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            var handler = (Socket)ar.AsyncState;
            try
            {
                _Client.EndConnect(ar);
                confrm.Status = "Connection Successful";
                confrm.ConnectionStatus(true);
                BeginReceive();
            }
            catch (Exception ex)
            {
                confrm.Status = "Connection Failed" + ex.Message;
            }
        }

        private void BeginReceive()
        {
            _buffer = new byte[8192];
            _Client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.Peek, new AsyncCallback(ReceiveCallback), _Client);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            int size = 0, rec = -1;

            var handler = (Socket)ar.AsyncState;
            //var handler = state.workSocket;

            rec = _Client.EndReceive(ar);
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
            _Client.BeginSend(BitConverter.GetBytes(buff.Length), 0, 4, SocketFlags.None, new AsyncCallback(SendCallback), _Client);
            _Client.BeginSend(buff, index, length, SocketFlags.None, new AsyncCallback(SendCallback), _Client);
        }
        private void SendCallback(IAsyncResult ar)
        {
            var handler= (Socket)ar.AsyncState;
            int sent = _Client.EndSend(ar);
        }

        public void RequestUserValidation(string username, string pass)
        {
            var data = _SM.UserValidation(username, pass);
            SendMessage(data);
        }

        public void RequestChatUsers()
        {
            var data = _SM.ChatUsers();
            SendMessage(data);
        }

        public void RequestToken()
        {
            var data = _SM.RequestToken();
            SendMessage(data);
        }

        public void SendChat(string msg, string token)
        {
            var data = _SM.ChatMsg(msg, token);
            SendMessage(data);
        }


    }
}
