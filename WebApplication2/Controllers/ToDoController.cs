using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemService todoItemService;

        public ToDoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {

            // todo Get to-do items from database
            var toDoItems = await todoItemService.GetIncompleteItemsAsync();
            // todo Put items into a model
            var model = new ToDoViewModel
            {
                Items = toDoItems
            };

            //todo Pass the view to a model and render

            return View(model);
        }

        public async Task<IActionResult> AddItem(NewTodoItem newItem)
        {
            if (!ModelState.IsValid) //if the model returns an error
            { //do stuff
                return BadRequest(ModelState);
            }
            //check if the adding is successful (we still need to add AddItemAsync as it throws an error)
            bool IsSuccessful = await todoItemService.AddItemAsync(newItem);
            if (!IsSuccessful) //if it fails
            {
                return BadRequest(new { error = "Could not add item" });
            }
            //otherwise, if it works return OK result
            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var successful = await todoItemService.MarkDoneAsync(id);
            if (!successful) return BadRequest();
            return Ok();
        }
    }
}