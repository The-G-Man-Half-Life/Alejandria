using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alejandria.Models;

namespace Alejandria.Controllers
{
    public class UserController : Controller
    {
<<<<<<< HEAD
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Accion para mostrar el formulario de creacion (GET)
        [HttpGet]
        public IActionResult CreateUser()
=======
        // Accion para mostrar el formulario de creacion (GET)
        [HttpGet]
        public IActionResult Create()
>>>>>>> 39a00b0da7027b983350036ca31c27275735b114
        {
            return View();
        }

        // Accion para manejar la sumision del formulario (POST)
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Aqui podrias guardar el usuario en una base de datos.
<<<<<<< HEAD

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
=======
                user.Id = Guid.NewGuid(); // Asigna un ID único al usuario.
>>>>>>> 39a00b0da7027b983350036ca31c27275735b114

                // Ejemplo de almacenamiento en una lista en memoria
                // _context.Users.Add(user);
                // _context.SaveChanges();

                // Redirige a una página de confirmacion o a la lista de usuarios.
                return RedirectToAction("Index");
            }

            // Si los datos no son válidos, vuelve a mostrar el formulario con los errores.
            return View(user);
        }

        public IActionResult Index()
        {
<<<<<<< HEAD
            return RedirectToAction(nameof(Index));
=======
            // Ejemplo de obtencion de datos de una base de datos
            // var users = _context.Users.ToList();
            var users = new List<User>(); // Lista vacia para ejemplo
            return View(users);
>>>>>>> 39a00b0da7027b983350036ca31c27275735b114
        }
    }
}