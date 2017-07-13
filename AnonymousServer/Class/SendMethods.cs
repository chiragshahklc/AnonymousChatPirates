using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    public class SendMethods
    {
        BinaryWriter bw;

        public void UserValidated()
        {
        }

        public byte[] WriteMemoryStream(MessageType command)
        {
            switch (command)
            {
                case MessageType.StartGroupChat:
                    {
                        return StartGroupChat();
                    }
                    break;
                default:
                    {
                        //return null;
                    }
                    break;
            }
            return null;
        }

        public byte[] StartGroupChat()
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.StartGroupChat.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] SendToken(string token)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.RequestToken.ToString().EncryptText());
            bw.Write(token.EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] UserValidation(bool IsValidated)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.UserValidation.ToString().EncryptText());
            bw.Write(IsValidated);
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] ChatUsers(List<LoginClass> list)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.ChatUsers.ToString().EncryptText());
            bw.Write(list.Count);
            foreach (var user in list)
            {
                bw.Write(user.name.EncryptText());
            }
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] ChatMsg(string msg, Usertype usertype)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.ChatMsg.ToString().EncryptText());
            bw.Write(msg.EncryptText());
            bw.Write(usertype.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }
    }
}

