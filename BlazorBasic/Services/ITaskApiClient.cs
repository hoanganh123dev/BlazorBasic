using BlazorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBasic.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
        Task<TaskDto> GetTaskDetail(string id);
    }
}
