using CTRL.Core.Interfaces;
using CTRL.Domain.Constants;
using CTRL.Domain.Interfaces;
using Dapper;
using System.Linq;

namespace CTRL.Domain.Repositories
{
    public class SetupsRepository : ISetupsRepository
    {
        IRepository repository;

        public SetupsRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public string GetPasswordSalt()
        {
            return repository.ExecuteStoredProcedureQuery<string>(DomainStoredProcedures.GetPasswordSalt, new DynamicParameters()).FirstOrDefault();
        }
    }
}
