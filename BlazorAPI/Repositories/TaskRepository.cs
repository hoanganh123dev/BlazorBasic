using BlazorAPI.Data;
using BlazorAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = BlazorAPI.Entities.Task;

namespace BlazorAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly BlazorDbContext _context;

        public TaskRepository(BlazorDbContext context)
        {
            _context = context;
        }
        public async Task<Task> Create(Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid Id)
        {
            return await _context.Tasks.FindAsync(Id);
        }

        public async Task<IEnumerable<Task>> GetTaskList()
        {
            return await _context.Tasks.Include(x =>x.Assignee)
                .ToListAsync();
        }

        public async Task<Task> Update( Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
