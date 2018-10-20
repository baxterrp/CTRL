using CTRL_Core.Domain.Classes.Contracts;

namespace CTRL_Core.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        void RegisterBusinessEntity(BusinessEntityRegistrationContract contract);

        void RegisterUserAndContact(UserRegistrationContract contract);
    }
}
