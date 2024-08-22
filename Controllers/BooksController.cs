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
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            // Cargar autores existentes para la selección
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View(new BookViewModel()); // Usamos un ViewModel para incluir tanto el libro como el autor
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el autor ya existe
                var existingAuthor = _context.Authors
                    .FirstOrDefault(a => a.AuthorName == viewModel.AuthorName && a.AuthorLastName == viewModel.AuthorLastName);

                if (existingAuthor == null)
                {
                    // Si no existe, agregar el nuevo autor
                    var newAuthor = new Author
                    {
                        AuthorId = Guid.NewGuid(), // Generar un nuevo ID para el autor
                        AuthorName = viewModel.AuthorName,
                        AuthorLastName = viewModel.AuthorLastName
                    };
                    _context.Authors.Add(newAuthor);
                    await _context.SaveChangesAsync();

                    // Asignar el ID del nuevo autor al libro
                    viewModel.Book.AuthorId = newAuthor.AuthorId;
                }
                else
                {
                    // Usar el autor existente
                    viewModel.Book.AuthorId = existingAuthor.AuthorId;
                }

                // Agregar el libro
                _context.Books.Add(viewModel.Book);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirige a la vista de índice
            }

            // Re-cargar los autores existentes si hay un error
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View(viewModel);
        }

        // GET: Books
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
    }
}
