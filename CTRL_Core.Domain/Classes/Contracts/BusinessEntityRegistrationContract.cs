using CTRL_Core.Backbone.Classes;
using CTRL_Core.Domain.Enumerations;

namespace CTRL_Core.Domain.Classes.Contracts
{
    public class BusinessEntityRegistrationContract
    {
        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; }

        public BusinessEntity BusinessEntity { get; set; }

        public UserRegistrationContract MainContact { get; set; }
    }
}
