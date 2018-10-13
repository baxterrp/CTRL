using CTRL.Domain.Interfaces;
using CTRL.Login.Interfaces;
using DevOne.Security.Cryptography.BCrypt;

namespace CTRL.Login
{
    public class PasswordEncryption : IPasswordEncryption
    {

        ISetupsConfiguration setupsConfiguration;

        public PasswordEncryption(ISetupsConfiguration setupsConfiguration)
        {
            this.setupsConfiguration = setupsConfiguration;
        }

        public bool CheckPassword(string userEnteredPassword, string databasePassword)
        {
            return BCryptHelper.CheckPassword(userEnteredPassword + setupsConfiguration.PasswordSalt, databasePassword);
        }

        public string EncryptPassword(string userEnteredPassword)
        {
            userEnteredPassword += setupsConfiguration.PasswordSalt;
            string hash = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(userEnteredPassword, hash);
        }
    }
}
