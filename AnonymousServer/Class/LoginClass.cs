using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    public class LoginClass
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Usertype usertype { get; set; }
        FileClass fc;
        List<FileDbStructure> db;

        public LoginClass()
        {
            fc = new FileClass();
            db = fc.GetDatabase();
        }

        public bool CheckLogin()
        {
            if (db.Exists(x => x.username == username))
            {
                var tmp = db.Find(x => x.username == username);
                if (tmp.password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void SetValues(string uname, string pwd, Usertype utype)
        {
            username = uname;
            password = pwd;
            usertype = utype;
        }

        public void SaveUser(string nme, string uname, string pwd, Usertype utype)
        {
            db.Add(new FileDbStructure(nme, uname, pwd, utype));
            fc.WriteToDbFile(db);
        }

        public bool DeleteUser(string username)
        {
            db.Remove(db.Find(x => x.username == username));
            fc.WriteToDbFile(db);
            return true;
        }

        public int CountUsers()
        {
            int count = db.Count(x => x.usertype == Usertype.Employee);
            return count;
        }

        public List<LoginClass> UserList()
        {
            return db.Select(x => new LoginClass { username = x.username }).ToList();
        }

        public List<LoginClass> ChatUsers()
        {
            return db.Select(x => new LoginClass { name = x.name }).ToList();
        }

        public string GetNameOfUser(string uname)
        {
            return db.Find(x => x.username == uname).name;
        }
    }
}
