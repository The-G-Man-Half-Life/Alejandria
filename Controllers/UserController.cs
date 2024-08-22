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
        // Accion para mostrar el formulario de creacion (GET)
        [HttpGet]
        public IActionResult Create()
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
                user.Id = Guid.NewGuid(); // Asigna un ID único al usuario.

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
            // Ejemplo de obtencion de datos de una base de datos
            // var users = _context.Users.ToList();
            var users = new List<User>(); // Lista vacia para ejemplo
            return View(users);
        }
    }
}