using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            List<User> list = new List<User>();
            list.Add(new User { Id = 1, Name = "Lucas Patrck", Sex = "Masculino", Email = "lucaspatrickccamara@gmail.com", Status = 0, BirthDate = DateTime.Now, CreatedDate = DateTime.Now, IndAtivo = 1 });
            list.Add(new User { Id = 2, Name = "Larissa Alves", Sex = "Feminino", Email = "larissaalves188@gmail.com", Status = 0, BirthDate = DateTime.Now, CreatedDate = DateTime.Now, IndAtivo = 1 });

            return View(list);
        }
    }
}
