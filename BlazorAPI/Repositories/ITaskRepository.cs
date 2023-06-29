using BlazorModel;
using BlazorModel.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = BlazorAPI.Entities.Task;

namespace BlazorAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<PagedList<Task>> GetTaskList(TaskListSearch taskListSearch);

        Task<Task> Create(Task task);

        Task<Task> Update(Task task);

        Task<Task> Delete(Task task);

        Task<Task> GetById(Guid id);

    }
}
