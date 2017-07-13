using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AnonymousServer
{
    public enum MessageType
    {
        RequestToken,
        StartGroupChat,
        UserValidation,
        ChatUsers,
        ChatMsg
    }
    public enum Usertype
    {
        Employee,
        Manager
    }
    public static class StaticMethods
    {

        public static List<TokenClass> TokensList { get; set; } = new List<TokenClass>();
        /// <summary>
        /// To Decrypt text.
        /// </summary>
        /// <param name="CipherText"></param>
        /// <returns></returns>
        public static string DecryptText(this string CipherText)
        {
            if (string.IsNullOrWhiteSpace(CipherText))
            {
                throw new ArgumentNullException(CipherText);
            }
            else
            {
                //Converts String to Bytes -- Use following method when you had converted binary data to string
                var buffer = Convert.FromBase64String(CipherText);

                //Use MD5 Encryptor to generate Key for DES using Keyword -- Bl@cKpeArL
                MD5CryptoServiceProvider _MD5Provider = new MD5CryptoServiceProvider();
                var hashKey = _MD5Provider.ComputeHash(Encoding.UTF8.GetBytes("Bl@cKpeArL"));
                _MD5Provider.Clear();

                TripleDESCryptoServiceProvider _CrypServProd = new TripleDESCryptoServiceProvider();
                _CrypServProd.Key = hashKey;
                _CrypServProd.Mode = CipherMode.ECB;
                _CrypServProd.Padding = PaddingMode.ISO10126;

                //Decrypt Byte[]
                var decryptedBytes = _CrypServProd.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length);
                _CrypServProd.Clear();

                //Converts Bytes to String -- Use following method when you had converted simple text data to bytes
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        /// <summary>
        /// To Encrypt text.
        /// </summary>
        /// <param name="PlainText">Text which needs to be encrypt.</param>
        /// <returns></returns>
        public static string EncryptText(this string PlainText)
        {
            if (string.IsNullOrWhiteSpace(PlainText))
            {
                throw new ArgumentNullException(PlainText);
            }
            else
            {
                //Converts String to Bytes -- Use following method when you convert simple text data to bytes
                var inputBuffer = Encoding.UTF8.GetBytes(PlainText);

                //Use MD5 Encryptor to generate Key for DES using Keyword -- Bl@cKpeArL
                MD5CryptoServiceProvider _MD5Provider = new MD5CryptoServiceProvider();
                var hashKey = _MD5Provider.ComputeHash(Encoding.UTF8.GetBytes("Bl@cKpeArL"));
                _MD5Provider.Clear();


                TripleDESCryptoServiceProvider _CrypServProvd = new TripleDESCryptoServiceProvider();
                _CrypServProvd.Key = hashKey;
                _CrypServProvd.Mode = CipherMode.ECB;
                _CrypServProvd.Padding = PaddingMode.ISO10126;

                //Encrypt Byte[]
                var encryptedBytes = _CrypServProvd.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                _CrypServProvd.Clear();

                //Returns Encrypted String - Use following method when Convert binary data to string
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static object TextToEnum<EnumType>(this string text)
        {
            return Enum.Parse(typeof(EnumType), text, true);

        }

        public static MemoryStream ToMemoryStream(this byte[] buff)
        {
            MemoryStream ms = new MemoryStream(buff.Length);
            ms.Write(buff, 0, buff.Length);
            ms.Position = 0;
            return ms;
        }

        public static string GenerateRandomToken()
        {
            Random rm = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[rm.Next(chars.Length)]).ToArray());
        }

      
    }
}
