﻿using System;
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
        public List<Service> MyServices { get; set; }
        public List<Inmate> MyFriends {get; set; }
        public List<Inmate> MyEnemies { get; set; }
    }
}