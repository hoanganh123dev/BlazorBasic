using BlazorBasic.Services;
using BlazorModel;
using BlazorModel.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBasic.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient taskApiClient { get; set; }
        [Inject] private IUserApiClient userApiClient { get; set; }

        private TaskListSearch TaskListSearch = new TaskListSearch();

        private List<TaskDto> Tasks;
        private List<AssigneeDto> Assignees;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await taskApiClient.GetTaskList();
            Assignees = await userApiClient.GetAssignees();
        }
    }
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Guid AssigneeId { get; set; }
        public Priority Priority { get; set; }
    }
}
