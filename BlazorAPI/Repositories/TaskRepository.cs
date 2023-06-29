﻿using BlazorAPI.Data;
using BlazorAPI.Entities;
using BlazorModel;
using BlazorModel.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagedList<Task>> GetTaskList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks
                .Include(x => x.Assignee).AsQueryable();

            if (!string.IsNullOrEmpty(taskListSearch.Name)) 
                query = query.Where(x => x.Name.Contains(taskListSearch.Name));

            if (taskListSearch.AssigneeId.HasValue)
                query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);

            if (taskListSearch.Priority.HasValue)
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);
            var count = await query.CountAsync();

            var data = await query.OrderByDescending(x => x.CreatedDate)
                .Skip((taskListSearch.PageNumber - 1) * taskListSearch.PageSize)
                .Take(taskListSearch.PageSize)
                .ToListAsync();
            return new PagedList<Entities.Task>(data, count, taskListSearch.PageNumber, taskListSearch.PageSize);

        }

        public async Task<Task> Update( Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
