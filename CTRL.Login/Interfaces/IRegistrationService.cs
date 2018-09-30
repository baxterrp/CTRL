using CTRL.Domain.Classes.Contracts;

namespace CTRL.Login.Interfaces
{
    public interface IRegistrationService
    {
        void RegisterBusinessEntity(BusinessEntityRegistrationContract contract);

        void RegisterNewUser(UserRegistrationContract contract);
    }
}
