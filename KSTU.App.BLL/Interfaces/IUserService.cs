using System.Collections.Generic;
using System.Threading.Tasks;
using KSTU.App.BLL.DTOs;

namespace KSTU.App.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string username, string password);
        Task<IEnumerable<UserDTO>> ListAll();
    }
}