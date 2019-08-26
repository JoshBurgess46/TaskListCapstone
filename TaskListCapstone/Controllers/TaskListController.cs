using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskListCapstone.Models;

namespace TaskListCapstone.Controllers
{
    [Authorize]
    public class TaskListController : Controller
    {
        private readonly TaskListDbContext _context;
        public TaskListController(TaskListDbContext context)
        {
            _context = context;
        }
        public IActionResult TaskList()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<TaskList> databaseList = _context.TaskList.ToList();
            
            List<TaskList> newTask = new List<TaskList>();
            AspNetUsers thisUser = _context.AspNetUsers.Where(u => u.UserName == User.Identity.Name).First();

            foreach (var item in databaseList)
            {
                if (id==item.Id)
                {

                }
            }
            return View(newTask);
        }
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskList newTask)
        {
            AspNetUsers thisUser = _context.AspNetUsers.Where(u => u.UserName == User.Identity.Name).First();
            newTask.Description = thisUser.Id;
            _context.TaskList.Add(newTask);
            _context.SaveChanges();
            return RedirectToAction("TaskList");
        }
    }
}