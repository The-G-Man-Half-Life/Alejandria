using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Models;

public class User
{
    public Guid Id { get; set; }
    public string IdentificationType { get; set; }
    public string IdentificationNumber { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    // Propiedad de navegación para los préstamos
    public ICollection<Loan> Loans { get; set; } 

}
