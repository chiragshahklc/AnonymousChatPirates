using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnonymousChatClient
{
    public class ReceiveMethods
    {
        BinaryReader br;
        public void ReadMemoryStream(MemoryStream ms, ClientSocket handler)
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
                case MessageType.StartGroupChat:
                    {
                        StartGroupChat(handler);
                    }
                    break;
                case MessageType.ChatUsers:
                    {
                        ChatUsers(br, handler);
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

        private void StartGroupChat(ClientSocket client)
        {
            client.StartChat();
        }
        private void UserValidation(BinaryReader br, ClientSocket client)
        {
            //bool IsValidated = br.ReadBoolean();
            client.IsValidated = br.ReadBoolean();
        }

        private void RequestToken(BinaryReader br, ClientSocket client)
        {
            string token = br.ReadString().DecryptText();
            client.SetChatToken(token);
        }
        private void ChatUsers(BinaryReader br, ClientSocket client)
        {
            int count = br.ReadInt32();
            List<string> users = new List<string>();
            for (int i = 0; i < count; i++)
            {
                users.Add(br.ReadString().DecryptText());
            }

            client.SetChatUsers(users);
        }

        private void ChatMsg(BinaryReader br, ClientSocket client)
        {
            string msg = br.ReadString().DecryptText();
            Usertype utype = (Usertype)br.ReadString().DecryptText().TextToEnum<Usertype>();
            client.MsgReceived(msg, utype);
        }
    }
}
