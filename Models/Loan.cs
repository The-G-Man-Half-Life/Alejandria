using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Models;
public class Loan
{
    public int LoanId { get; set; } // Clave primaria
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime LimitDate { get; set; }
    public DateTime DevolutionDate { get; set; }

    // Propiedades de navegación
    public User User { get; set; }
    public Book Book { get; set; }

    public Loan()
    {}
}