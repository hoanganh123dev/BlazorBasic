using BlazorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBasic.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();

    }
}
