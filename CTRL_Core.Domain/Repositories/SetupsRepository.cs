using CTRL_Core.Backbone.Interfaces;
using CTRL_Core.Domain.Constants;
using CTRL_Core.Domain.Interfaces;
using Dapper;
using System.Linq;

namespace CTRL_Core.Domain.Repositories
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
