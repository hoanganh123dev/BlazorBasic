using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = BlazorAPI.Entities.Task;

namespace BlazorAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTaskList();

        Task<Task> Create(Task task);
        Task<Task> Update(Guid Id,Task task);
        Task<Task> Delete(Task task);
        Task<Task> GetById(Guid Id);

    }
}
