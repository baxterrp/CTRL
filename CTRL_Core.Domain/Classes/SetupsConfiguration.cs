using CTRL_Core.Domain.Interfaces;

namespace CTRL_Core.Domain.Classes
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
