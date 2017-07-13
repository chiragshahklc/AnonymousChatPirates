using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    class ReceiveMethods
    {
        BinaryReader br;
        SendMethods _SM;

        public ReceiveMethods()
        {
            _SM = new SendMethods();
        }
        public void ReadMemoryStream(MemoryStream ms, ClientSockets handler)
        {
            br = new BinaryReader(ms);
            MessageType command = (MessageType)br.ReadString().DecryptText().TextToEnum<MessageType>();
            switch (command)
            {
                case MessageType.UserValidation:
                    {
                        UserValidation(br, handler);
                    }
                    break;
                case MessageType.RequestToken:
                    {
                        RequestToken(br, handler);
                    }
                    break;
                case MessageType.ChatUsers:
                    {
                        ChatUsers(handler);
                    }
                    break;
                case MessageType.ChatMsg:
                    {
                        ChatMsg(br, handler);
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }

        public void UserValidation(BinaryReader br, ClientSockets client)
        {
            string uname, pwd;
            Usertype utype;
            uname = br.ReadString().DecryptText();
            pwd = br.ReadString().DecryptText();
            utype = (Usertype)br.ReadString().DecryptText().TextToEnum<Usertype>();

            LoginClass lc = new LoginClass();
            lc.SetValues(uname, pwd, utype);
            var IsValidated = lc.CheckLogin();

            var data = _SM.UserValidation(IsValidated);
            client.SendMessage(data);
            client.Name = lc.GetNameOfUser(uname);
            client.IsValidated = true;
        }

        public void RequestToken(BinaryReader br, ClientSockets client)
        {
            StaticMethods.TokensList.Add(new TokenClass(client.Port));
            client.TokenRequested = 1;
        }

        public void ChatUsers(ClientSockets client)
        {
            var list = new LoginClass().ChatUsers();
            var data = _SM.ChatUsers(list);
            client.SendMessage(data);
        }

        public void ChatMsg(BinaryReader br, ClientSockets client)
        {
            string msg = br.ReadString().DecryptText();
            string token = br.ReadString().DecryptText();
            client.Log = "'" + token + "' token received from "+ client.Port;
            Usertype utype = (Usertype)br.ReadString().DecryptText().TextToEnum<Usertype>();
            if (client.tokenValue == token)
            {
                client.Log = "Token Verified.";
                var data = _SM.ChatMsg(msg, utype);
                client.BroadcastMsg(data);
                client.SendMsgToServer(msg, utype);
            }
        }
    }
}
