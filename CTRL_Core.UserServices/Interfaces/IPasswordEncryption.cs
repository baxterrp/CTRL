namespace CTRL_Core.UserServices.Interfaces
{
    public interface IPasswordEncryption
    {
        string EncryptPassword(string userEnteredPassword);

        bool CheckPassword(string userEnteredPassword, string databasePassword);
    }
}
