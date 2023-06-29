using BlazorModel.Enums;
using BlazorModel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorModel
{
    public class TaskListSearch : PagingParameters
    {
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public Priority? Priority { get; set; }
    }
}
