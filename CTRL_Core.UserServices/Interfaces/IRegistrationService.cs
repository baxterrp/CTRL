using CTRL_Core.Domain.Classes.Contracts;

namespace CTRL_Core.Login.Interfaces
{
    public interface IRegistrationService
    {
        void RegisterBusinessEntity(BusinessEntityRegistrationContract contract);

        void RegisterNewUser(UserRegistrationContract contract);
    }
}
