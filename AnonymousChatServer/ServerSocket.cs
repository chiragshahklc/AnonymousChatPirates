using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace AnonymousChatServer
{
    public class ServerSocket
    {
        Socket _ServerSocket;
        List<ClientSockets> clients;

        public ServerSocket()
        {
            _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<ClientSockets>();
        }

        public void StartServer()
        {
            _ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 9192));
            _ServerSocket.Listen(0);
            Console.WriteLine("\r\nServer Started Successfully.\r\nServer listening on "+_ServerSocket.LocalEndPoint.ToString()+"");
            BeginAccept();
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            ClientSockets client = new ClientSockets(_ServerSocket.EndAccept(ar), "Unknown"+ (clients.Count)+1 +"");
            clients.Add(client);
            Console.WriteLine(client.GetName() + " has been Connected.");

            BeginAccept();
        }

        private void BeginAccept()
        {
            _ServerSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
    }
}
