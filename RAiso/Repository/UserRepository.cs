using RAiso.Model;
using System;
using System.Linq;

namespace RAiso.Repository
{
    public class UserRepository
    {
        private static readonly DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static MsUser GetUser(string name, string password)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserName == name && u.UserPassword == password);
        }

        public static MsUser GetUserByName(string name)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserName == name);
        }

        public static MsUser GetUserById(string id)
        {
            if (int.TryParse(id, out int userId))
            {
                return db.MsUsers.FirstOrDefault(u => u.UserId == userId);
            }
            return null;
        }

        public static MsUser GetLastUser()
        {
            return db.MsUsers.OrderByDescending(u => u.UserId).FirstOrDefault();
        }

        public static void InsertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static void UpdateUser(string name, DateTime dob, string gender, string address, string password, string phone, int id)
        {
            var user = db.MsUsers.Find(id);
            if (user != null)
            {
                user.UserName = name;
                user.UserDOB = dob;
                user.UserGender = gender;
                user.UserAddress = address;
                user.UserPassword = password;
                user.UserPhone = phone;
                db.SaveChanges();
            }
        }
    }
}
