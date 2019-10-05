using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.Models;

namespace ClinkedIn.Api.Commands
{
    public class AddEnemyCommand
    {
        public string Name { get; set; }
        public CriminalInterest CriminalInterest { get; set; }
    }
}
