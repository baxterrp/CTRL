using CTRL.Core.Classes;
using CTRL.Core.Interfaces;
using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Constants;
using CTRL.Domain.Interfaces;
using Dapper;
using System.Linq;

namespace CTRL.Domain.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        IRepository repository;

        public RegistrationRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public void RegisterUserAndContact(UserRegistrationContract contract)
        {
            var contactId = RegisterNewUser(contract);
            RegisterNewContact(contactId, contract);
        }

        public void RegisterBusinessEntity(BusinessEntityRegistrationContract contract)
        {
            var contactId = RegisterNewUser(contract.MainContact);
            RegisterNewContact(contactId, contract.MainContact);
            var addressId = RegisterNewAddress(contract.CompanyAddress);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name", contract.CompanyName);
            parameters.Add("@entity", (int)contract.BusinessEntity);
            parameters.Add("@contact", contactId);
            parameters.Add("@addressId", addressId);

            repository.ExecuteStoredProcedureCommand(DomainStoredProcedures.RegisterNewBusiness, parameters);
        }

        private void RegisterNewContact(int userId, UserRegistrationContract contract)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@user_id", userId);
            parameters.Add("@first_name", contract.Name.FirstName);
            parameters.Add("@last_name", contract.Name.LastName);
            parameters.Add("@phone_number", contract.PhoneNumber);

            repository.ExecuteStoredProcedureCommand(DomainStoredProcedures.RegisterNewContact, parameters);
        }

        private int RegisterNewUser(UserRegistrationContract contract)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", contract.Email);
            parameters.Add("@password", contract.Password);

            return repository.ExecuteStoredProcedureQuery<int>(DomainStoredProcedures.RegisterNewUser, parameters).First();
        }

        private int RegisterNewAddress(Address address)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@address_line_one", address.AddressLineOne);
            parameters.Add("@address_line_two", !string.IsNullOrEmpty(address.AddressLineTwo) ? address.AddressLineTwo : string.Empty);
            parameters.Add("@city", address.City);
            parameters.Add("@state", address.State);
            parameters.Add("@zip", address.Zip);

            return repository.ExecuteStoredProcedureQuery<int>(DomainStoredProcedures.RegisterNewAddress, parameters).First();
        }
    }
}
