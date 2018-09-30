using CTRL.Core.Classes;

namespace CTRL.Domain.Classes.Contracts
{
    public class UserRegistrationContract
    {
        public string Email { get; set; }

        public Name Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
