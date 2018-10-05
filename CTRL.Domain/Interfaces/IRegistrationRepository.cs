using CTRL.Domain.Classes.Contracts;

namespace CTRL.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        void RegisterBusinessEntity(BusinessEntityRegistrationContract contract);

        void RegisterUserAndContact(UserRegistrationContract contract);
    }
}
