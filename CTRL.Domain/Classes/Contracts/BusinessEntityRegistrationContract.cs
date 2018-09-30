using CTRL.Core.Classes;
using CTRL.Domain.Enumerations;

namespace CTRL.Domain.Classes.Contracts
{
    public class BusinessEntityRegistrationContract
    {
        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; }

        public BusinessEntity BusinessEntity { get; set; }

        public UserRegistrationContract MainContact { get; set; }
    }
}
