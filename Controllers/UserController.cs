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
            // Cargar autores existentes para la selección
            ViewBag.Users = new SelectList(_context.Users);
            return View(); // Usamos un ViewModel para incluir tanto el libro como el autor
        }

        // Accion para manejar la sumision del formulario (POST)
        [HttpPost]
        public async Task<IActionResult> Create(User modelUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(a => a.Name == modelUser.Name && a.LastName == modelUser.LastName);
                // Aqui podrias guardar el usuario en una base de datos.
                
                if (existingUser == null)
                {
                    var newUser = new User
                    {
                        Id = Guid.NewGuid(), // Asigna un ID único al usuario.
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

            // Re-cargar los Usuarios existentes si hay un error
            ViewBag.Users = new SelectList(_context.Users, "IdentificationNumber");
            // Si los datos no son válidos, vuelve a mostrar el formulario con los errores.
            return View(modelUser);
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}