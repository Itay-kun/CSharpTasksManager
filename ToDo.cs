using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ToDoItem
    {
        public string Key { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ParentTaskKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public ToDoItem(string title, string description, string parentTaskKey, DateTime startDate, DateTime endDate)
        {
            Key = DateTime.Now.ToString("yyMMddHHmmss");
            Title = title;
            Description = description;
            ParentTaskKey = parentTaskKey;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"Key: {Key}, Title: {Title}, Description: {Description}, " +
                   $"ParentTaskKey: {ParentTaskKey}, StartDate: {StartDate}, EndDate: {EndDate}";
        }
    }
}
