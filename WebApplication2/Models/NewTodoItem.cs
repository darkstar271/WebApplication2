using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class NewTodoItem
    {
        [Required] //Required means you can't make a new Entry without the Title field
        public string Title { get; set; }
    }
}
