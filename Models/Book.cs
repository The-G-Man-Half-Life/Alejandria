using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Models;
public class Book
{
    public Guid Id { get; set; } // Clave primaria
    // public string LocationCode { get; set; }
    public string Title { get; set; }
    public Guid AuthorId { get; set; } // Clave foránea
    public string LiteraryGenre { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string ISBN { get; set; }
    public string StatusValue { get; set; }

    // Propiedades de navegación
    public Author Author { get; set; }
    // public Location Location { get; set; }
    public required ICollection<Loan> Loans { get; set; }

}
