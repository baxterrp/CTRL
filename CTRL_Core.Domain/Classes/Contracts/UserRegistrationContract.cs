using CTRL_Core.Backbone.Classes;

namespace CTRL_Core.Domain.Classes.Contracts
{
    public class UserRegistrationContract
    {
        public string Email { get; set; }

        public Name Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
