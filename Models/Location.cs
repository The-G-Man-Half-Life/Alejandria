using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace Alejandria.Models
{
    public class Location
    {
        public string LocationCode {get; set;}
        public string Title {get; set;}
        public int CopyNumber {get; set;}


        public Location(string LocationCode ,string Title ,int CopyNumber)
        {
            this.LocationCode = LocationCode;
            this.Title = Title;
            this.CopyNumber = CopyNumber;
        }
    }
}