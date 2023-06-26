using BlazorBasic.Services;
using BlazorModel;
using BlazorModel.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
            Tasks = await taskApiClient.GetTaskList(TaskListSearch);
            Assignees = await userApiClient.GetAssignees();
        }
        private async Task SearchForm(EditContext context)
        {
            Tasks = await taskApiClient.GetTaskList(TaskListSearch);
        }
    }
    
}
