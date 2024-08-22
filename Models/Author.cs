using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alejandria.Models;
public class Author
{
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorLastName { get; set; }

    // Propiedad de navegación para los libros
    public ICollection<Book> Books { get; set; }

    // Constructor for Author 
    public Author() { }
}