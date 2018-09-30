using CTRL.Domain.Classes;
using CTRL.Domain.Classes.Contracts;

namespace CTRL.Login.Interfaces
{
    public interface ILoginService
    {
        UserProfile GetUser(LoginContract contract);
    }
}
