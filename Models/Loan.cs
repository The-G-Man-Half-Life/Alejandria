using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Models;
public class Loan
{
    public int LoanId { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime LimitDate { get; set; }
    public DateTime DevolutionDate { get; set; }

    public Loan(int LoanId, int UserId, DateTime dateTime, DateTime limitDate, DateTime devolutionDate)
    {}
}