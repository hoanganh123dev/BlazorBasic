using BlazorModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBasic.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskDto> GetTaskDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/tasks/{id}");
            return result;
        }

        public async Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            string url = $"/api/tasks?name={taskListSearch.Name}&asssigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return result;
        }
        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/tasks", request);
            return result.IsSuccessStatusCode;

        }

        public async Task<bool> UpdateTask(Guid id, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{id}", request);
            return result.IsSuccessStatusCode;

        }
        public async Task<bool> AssignTask(Guid id, AssignTaskRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{id}/assign", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteTask(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/tasks/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
