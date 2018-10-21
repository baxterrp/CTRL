using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Classes.Contracts;

namespace CTRL_Core.Domain.Interfaces
{
    public interface ILoginRepository
    {
        UserProfile GetUser(LoginContract contract);
    }
}
