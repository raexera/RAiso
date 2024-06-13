using RAiso.Handler;
using RAiso.Model;
using System;
using System.Text.RegularExpressions;

namespace RAiso.Controller
{
    public class UserController
    {
        private static string ValidateField(string fieldValue, Func<string, string> validationFunction)
        {
            string result = validationFunction(fieldValue);
            return result;
        }

        public static string CheckUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "Username must be filled";
            return "";
        }

        public static string CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Password must be filled";
            return "";
        }

        public static string ValidateLogin(string name, string password)
        {
            string result = CheckUsername(name);
            if (string.IsNullOrEmpty(result))
                result = CheckPassword(password);
            if (string.IsNullOrEmpty(result))
                result = UserHandler.HandleLogin(name, password);
            return result;
        }

        public static string CheckUsernameRegister(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "Username must be filled";
            if (name.Length < 5 || name.Length > 50)
                return "Username must be between 5 and 50 characters";
            return "";
        }

        public static string CheckDOB(string dob)
        {
            if (string.IsNullOrEmpty(dob))
                return "Date of Birth must be filled";

            if ((DateTime.Now - DateTime.Parse(dob)).TotalDays < 365)
                return "Must be at least 1 year of age";

            return "";
        }

        public static string CheckGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
                return "Gender must be selected";
            return "";
        }

        public static string CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                return "Address must be filled";
            return "";
        }

        public static string CheckPasswordRegister(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Password must be filled";
            if (!Regex.IsMatch(password, "^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$"))
                return "Password must be alphanumeric";
            return "";
        }

        public static string CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return "Phone must be filled";
            return "";
        }

        public static string ValidateRegister(string name, string dob, string gender, string address, string password, string phone)
        {
            string result = ValidateField(name, CheckUsernameRegister);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(dob, CheckDOB);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(gender, CheckGender);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(address, CheckAddress);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(password, CheckPasswordRegister);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(phone, CheckPhone);
            if (string.IsNullOrEmpty(result))
                result = UserHandler.HandleRegister(name);
            return result;
        }

        public static string ValidateUpdate(string name, string dob, string gender, string address, string password, string phone, string nameFirst)
        {
            string result = ValidateField(name, CheckUsernameRegister);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(dob, CheckDOB);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(gender, CheckGender);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(address, CheckAddress);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(password, CheckPasswordRegister);
            if (string.IsNullOrEmpty(result))
                result = ValidateField(phone, CheckPhone);
            if (string.IsNullOrEmpty(result))
                result = UserHandler.HandleUpdate(name, nameFirst);
            return result;
        }

        public static string GetRole(string id)
        {
            return UserHandler.GetRole(id);
        }

        public static MsUser GetUserByName(string name)
        {
            return UserHandler.GetUserByName(name);
        }

        public static MsUser GetUserById(string id)
        {
            return UserHandler.GetUserById(id);
        }

        public static void InsertUser(string name, DateTime dob, string gender, string address, string password, string phone)
        {
            UserHandler.HandleInsert(name, dob, gender, address, password, phone);
        }

        public static void UpdateUser(string name, DateTime dob, string gender, string address, string password, string phone, int id)
        {
            UserHandler.UpdateUser(name, dob, gender, address, password, phone, id);
        }
    }
}
