using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Models;
public class Book
{
    public Guid Id { get; set; }
    public string LocationCode { get; set; }
    public string LiteraryGenre { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string ISBN { get; set; }
    public string StatusValue { get; set; }

    public Book(Guid id, string locationCode, string literaryGenre, DateOnly publicationDate, string iSBN, string statusValue)
    {}
}
