using CTRL_Core.Domain.Classes.Contracts;
using CTRL_Core.Domain.Interfaces;
using CTRL_Core.UserServices.Interfaces;

namespace CTRL_Core.UserServices
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
