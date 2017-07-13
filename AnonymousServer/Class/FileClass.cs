using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    public class FileClass
    {
        public List<FileDbStructure> GetDatabase()
        {
            List<FileDbStructure> db = new List<FileDbStructure>();
            string path = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), @"FileDB\Database.aca");
            var cipherTexts = File.ReadAllLines(path);
            foreach (string str in cipherTexts)
            {
                db.Add(FromCipherLine(str));
            }
            return db;
        }

        public bool WriteToDbFile(List<FileDbStructure> DbFile)
        {
            List<string> tmp = new List<string>();
            foreach (var x in DbFile)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(x.name.EncryptText());
                sb.Append(";");
                sb.Append(x.username.EncryptText());
                sb.Append(";");
                sb.Append(x.password.EncryptText());
                sb.Append(";");
                sb.Append(x.usertype.ToString().EncryptText());
                sb.Append(";");
                tmp.Add(sb.ToString());
            }

            var strArray = tmp.ToArray();
            string path = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), @"FileDB\Database.aca");
            File.WriteAllLines(path, strArray);
            return true;

        }

        private FileDbStructure FromCipherLine(string line)
        {
            int x = line.IndexOf(';');
            var name = line.Substring(0, x);
            int y = line.IndexOf(';', x + 1);
            var uname = line.Substring(x + 1, y - (x + 1));
            int z = line.IndexOf(';', y + 1);
            var pwd = line.Substring(y + 1, z - (y + 1));
            int z2 = line.IndexOf(';', z + 1);
            var utype = line.Substring(z + 1, z2 - (z + 1));
            FileDbStructure dbs = new FileDbStructure(name.DecryptText(), uname.DecryptText(), pwd.DecryptText(), (Usertype)utype.DecryptText().TextToEnum<Usertype>());
            return dbs;
        }





    }
}
