using BlazorBasic.Services;
using BlazorModel;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBasic.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient taskApiClient { get; set; }

        private List<TaskDto> Tasks;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await taskApiClient.GetTaskList();
        }
    }
}
