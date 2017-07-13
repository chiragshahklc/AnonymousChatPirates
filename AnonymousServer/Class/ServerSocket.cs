using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AnonymousServer
{
    public class ServerSocket
    {
        Socket _ServerSocket;
        List<ClientSockets> clients;
        SendMethods _SM;
        Login frmLogin;
        public int TotalUsers
        {
            get
            {
                return new LoginClass().CountUsers();
            }
        }
        public int ConnectedUsers
        {
            get
            {
                return clients.Count(x => x.IsValidated == true);
            }
        }

        public ServerSocket(Login frm)
        {
            _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<ClientSockets>();
            _SM = new SendMethods();
            frmLogin = frm;
        }

        public void StartServer()
        {
            _ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 9192));
            _ServerSocket.Listen(0);
            frmLogin.Status = "Server Started.";
            BeginAccept();
            UpdateConnectedUsersLabel();
        }

        public void UpdateConnectedUsersLabel()
        {
            string tmp = "Connected Users: " + ConnectedUsers + "/" + TotalUsers;
            frmLogin.GetConnectedUsers = tmp;
            if (TotalUsers == ConnectedUsers)
            {
                frmLogin.CanStartChat = true;
            }
        }

        public void UpdateConnectedUserName(string name)
        {
            frmLogin.ConnectedUserList(name);
        }
        public List<LoginClass> GetUserList()
        {
            return new LoginClass().UserList();

        }


        public void RequestBroadcast(MessageType command)
        {
            var data = _SM.WriteMemoryStream(command);
            BroadcastToEveryone(data);
        }
        public void BroadcastToEveryone(byte[] buf)
        {
            foreach (ClientSockets clnt in clients)
            {

                clnt.SendMessage(buf);
            }
        }


        private void BeginAccept()
        {
            _ServerSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            var handler = _ServerSocket.EndAccept(ar);
            ClientSockets client = new ClientSockets(handler, "Unknown", this);
            clients.Add(client);
            frmLogin.Status = client.IPAddress + " Connected.";
            BeginAccept();
        }

        public void SendMsgToServer(string msg, Usertype utype)
        {
            frmLogin.MsgReceive(msg, utype);
        }

        public void TokenRequested(int val, string port)
        {
            frmLogin.TokenRequested = val;
            frmLogin.GetLog = port + " Requests Token.";
        }

        public void SendToken(string port)
        {
            var handle = clients.Find(x => x.Port == port);
            var token = StaticMethods.GenerateRandomToken();
            var data = _SM.SendToken(token);
            handle.tokenValue = token;
            handle.SendMessage(data);
            frmLogin.GetLog = "'"+token+"' token generated for "+ port;
            frmLogin.TokenRequested = -1;
        }

        public void Log(string val)
        {
            frmLogin.GetLog = val;
        }
    }
}
