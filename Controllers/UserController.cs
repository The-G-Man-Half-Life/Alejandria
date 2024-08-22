using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alejandria.Data;
using Alejandria.Models;
using Alejandria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alejandria.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Accion para mostrar el formulario de creacion (GET)
        [HttpGet]
        public IActionResult CreateUser()
        {
            ViewBag.Users = new SelectList(_context.Users);
            return View();
        }

        // Accion para manejar la sumision del formulario (POST)
        [HttpPost]
        public async Task<IActionResult> Create(User modelUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(a => a.Name == modelUser.Name && a.LastName == modelUser.LastName);

                if (existingUser == null)
                {
                    var newUser = new User
                    {
                        Id = Guid.NewGuid(),
                        IdentificationType = modelUser.IdentificationType,
                        IdentificationNumber = modelUser.IdentificationNumber,
                        Name = modelUser.Name,
                        LastName = modelUser.LastName,
                        Address = modelUser.Address,
                        Gender = modelUser.Gender,
                        PhoneNumber = modelUser.PhoneNumber,
                    };
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(modelUser);
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList(); // Obtén la lista de usuarios desde la base de datos
            return View(users); // Pasa la lista de usuarios a la vista y devuélvela
        }
    }
}