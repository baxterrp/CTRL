namespace CTRL.Login.Interfaces
{
    public interface IPasswordEncryption
    {
        string EncryptPassword(string userEnteredPassword);

        bool CheckPassword(string userEnteredPassword, string databasePassword);
    }
}
