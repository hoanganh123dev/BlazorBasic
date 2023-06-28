using BlazorBasic.Components;
using BlazorBasic.Pages.Components;
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
        protected Confirmation DeleteConfirmation { set; get; }
        protected AssignTask AssignTaskDialog { set; get; }
        private Guid DeleteId { set; get; }

        private TaskListSearch TaskListSearch = new TaskListSearch();

        private List<TaskDto> Tasks;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await taskApiClient.GetTaskList(TaskListSearch);
        }

        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            Tasks = await taskApiClient.GetTaskList(TaskListSearch);
        }
        public void OnDeleteTask(Guid deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await taskApiClient.DeleteTask(DeleteId);
                Tasks = await taskApiClient.GetTaskList(TaskListSearch);

            }
        }
        public void OpenAssignPopup(Guid id)
        {
            AssignTaskDialog.Show(id);
        }
        public async Task AssignTaskSuccess(bool result)
        {
            if (result)
            {
                Tasks = await taskApiClient.GetTaskList(TaskListSearch);
            }
        }
    }
    
}
