using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Models
{
    public class Inmate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CriminalInterest CriminalInterest { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> MyServices { get; set; } = new List<string>();
        public List<string> MyFriends { get; set; } = new List<string>();
        public List<string> MyEnemys { get; set; } = new List<string>();
    }
     
    public enum CriminalInterest
    {
        Robbery,
        Assault,
        Murder,
        Bribery
    }
}
