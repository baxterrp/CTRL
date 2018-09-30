using CTRL.Domain.Classes;
using CTRL.Domain.Classes.Contracts;

namespace CTRL.Domain.Interfaces
{
    public interface ILoginRepository
    {
        UserProfile GetUser(LoginContract contract);
    }
}
