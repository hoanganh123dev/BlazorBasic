using BlazorBasic.Components;
using BlazorBasic.Pages.Components;
using BlazorBasic.Services;
using BlazorBasic.Shared;
using BlazorModel;
using BlazorModel.Enums;
using BlazorModel.SeedWork;
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
        public MetaData MetaData { get; set; } = new MetaData();
        [CascadingParameter]
        private Error Error { set; get; }
        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
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
                await GetTasks();

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
                await GetTasks();
            }
        }
        private async Task GetTasks()
        {
            try
            {
                var pagingResponse = await taskApiClient.GetTaskList(TaskListSearch);
                Tasks = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }

        }
        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }
    
}
