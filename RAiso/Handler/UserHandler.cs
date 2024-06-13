using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;

namespace RAiso.Handler
{
    public class UserHandler
    {
        private static MsUser GetUser(string name)
        {
            return UserRepository.GetUserByName(name);
        }

        public static string HandleLogin(string name, string password)
        {
            MsUser user = UserRepository.GetUser(name, password);
            return user != null ? "Success" : "Username or Password is incorrect";
        }

        public static string HandleRegister(string name)
        {
            MsUser user = GetUser(name);
            return user == null ? "Success" : "Username already exists";
        }

        private static int GenerateID()
        {
            int id = 0;
            MsUser user = UserRepository.GetLastUser();
            if (user == null)
            {
                id = 1;
            }
            else
            {
                id = user.UserId + 1;
            }
            return id;
        }

        public static void HandleInsert(string name, DateTime dob, string gender, string address, string password, string phone)
        {
            MsUser user = UserFactory.CreateUser(GenerateID(), name, dob, gender, address, password, phone, "Customer");
            UserRepository.InsertUser(user);
        }

        public static string GetRole(string Id)
        {
            MsUser user = UserRepository.GetUserById(Id);
            return user.UserRole;
        }

        public static MsUser GetUserByName(string name)
        {
            return GetUser(name);
        }

        public static MsUser GetUserById(string Id)
        {
            return UserRepository.GetUserById(Id);
        }

        public static string HandleUpdate(string name, string nameFirst)
        {
            MsUser user = GetUserByName(name);
            if (name.Equals(nameFirst))
            {
                return "Success";
            }
            else
            {
                return GetUser(nameFirst) == null ? "Success" : "Username already exists";
            }
        }

        public static void UpdateUser(string name, DateTime dob, string gender, string address, string password, string phone, int Id)
        {
            UserRepository.UpdateUser(name, dob, gender, address, password, phone, Id);
        }
    }
}
