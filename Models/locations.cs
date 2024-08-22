using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace Alejandria.Models
{
    public class locations
    {
        public Guid LocationCode {get; set;}
        public string Title {get; set;}
        public int CopyNumber {get; set;}


        public locations(Guid LocationCode ,string Title ,int CopyNumber)
        {
            this.LocationCode = new Guid();
            this.Title = Title;
            this.CopyNumber = CopyNumber;
        }
    }
}