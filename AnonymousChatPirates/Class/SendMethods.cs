using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnonymousChatClient
{
    public class SendMethods
    {
        BinaryWriter bw;
        public byte[] UserValidation(string uname, string pwd)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.UserValidation.ToString().EncryptText());
            bw.Write(uname.EncryptText());
            bw.Write(pwd.EncryptText());
            bw.Write(Usertype.Employee.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] ChatUsers()
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.ChatUsers.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] RequestToken()
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.RequestToken.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }

        public byte[] ChatMsg(string msg, string token)
        {
            bw = new BinaryWriter(new MemoryStream());
            bw.Write(MessageType.ChatMsg.ToString().EncryptText());
            bw.Write(msg.EncryptText());
            bw.Write(token.EncryptText());
            bw.Write(Usertype.Employee.ToString().EncryptText());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            return data;
        }
    }
}
