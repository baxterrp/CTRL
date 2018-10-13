using CTRL.Domain.Interfaces;

namespace CTRL.Domain.Classes
{
    public class SetupsConfiguration : ISetupsConfiguration
    {
        ISetupsRepository setupsRepository;

        public SetupsConfiguration(ISetupsRepository setupsRepository)
        {
            this.setupsRepository = setupsRepository;
            PasswordSalt = setupsRepository.GetPasswordSalt();
        }

        public string PasswordSalt { get; }
    }
}
