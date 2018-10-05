using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Interfaces;
using CTRL.Login.Interfaces;

namespace CTRL.Login
{
    public class RegistrationService : IRegistrationService
    {
        IRegistrationRepository registrationRepository;
        IPasswordEncryption passwordEncryption;

        public RegistrationService(IRegistrationRepository registrationRepository, IPasswordEncryption passwordEncryption)
        {
            this.registrationRepository = registrationRepository;
            this.passwordEncryption = passwordEncryption;
        }

        public void RegisterBusinessEntity(BusinessEntityRegistrationContract contract)
        {
            contract.MainContact.Password = passwordEncryption.EncryptPassword(contract.MainContact.Password);
            registrationRepository.RegisterBusinessEntity(contract);
        }

        public void RegisterNewUser(UserRegistrationContract contract)
        {
            contract.Password = passwordEncryption.EncryptPassword(contract.Password);
            registrationRepository.RegisterUserAndContact(contract);
        }
    }
}
