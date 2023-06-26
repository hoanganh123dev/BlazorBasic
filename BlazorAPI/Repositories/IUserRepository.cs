using BlazorAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();

    }
}
