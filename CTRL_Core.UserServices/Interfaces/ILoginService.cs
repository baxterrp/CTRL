using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Classes.Contracts;

namespace CTRL_Core.Login.Interfaces
{
    public interface ILoginService
    {
        UserProfile GetUser(LoginContract contract);
    }
}
