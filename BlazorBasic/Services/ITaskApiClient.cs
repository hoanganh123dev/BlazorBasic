using BlazorModel;
using BlazorModel.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBasic.Services
{
    public interface ITaskApiClient
    {
        Task<PagedList<TaskDto>> GetTaskList(TaskListSearch taskListSearch);
        Task<TaskDto> GetTaskDetail(string id);
        Task<bool> CreateTask(TaskCreateRequest request);
        Task<bool> UpdateTask(Guid id, TaskUpdateRequest request);
        Task<bool> DeleteTask(Guid id);
        Task<bool> AssignTask(Guid id, AssignTaskRequest request);

    }
}
