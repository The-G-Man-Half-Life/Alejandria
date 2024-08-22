using System.ComponentModel.DataAnnotations;
using Alejandria.Models;

namespace Alejandria.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        // Campos adicionales para el autor
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Display(Name = "Author Last Name")]
        public string AuthorLastName { get; set; }
    }
}
