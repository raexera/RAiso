using RAiso.Model;
using System;

namespace RAiso.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(int id, String name, DateTime dob, String gender, String address, String password, String phone, String role)
        {
            MsUser user = new MsUser
            {
                UserId = id,
                UserName = name,
                UserGender = gender,
                UserDOB = dob,
                UserPhone = phone,
                UserAddress = address,
                UserPassword = password,
                UserRole = role
            };

            return user;
        }
    }
}