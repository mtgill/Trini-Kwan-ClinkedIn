using ClinkedIn.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Commands
{
    public class AddInmateCommand
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public CriminalInterest CriminalInterest { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
