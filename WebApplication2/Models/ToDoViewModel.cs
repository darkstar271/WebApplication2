using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> Items
        { get; set; }

    }
}
