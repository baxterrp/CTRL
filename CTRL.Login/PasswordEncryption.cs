using CTRL.Login.Interfaces;
using DevOne.Security.Cryptography.BCrypt;

namespace CTRL.Login
{
    public class PasswordEncryption : IPasswordEncryption
    {
        private const string Salt = "2n*5vu^w0~o3**z";

        public bool CheckPassword(string userEnteredPassword, string databasePassword)
        {
            return BCryptHelper.CheckPassword(userEnteredPassword + Salt, databasePassword);
        }

        public string EncryptPassword(string userEnteredPassword)
        {
            userEnteredPassword += Salt;
            string hash = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(userEnteredPassword, hash);
        }
    }
}
