﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Commands
{
    public class BuildCrewCommand
    {
        public string Name { get; set; }
        public List<string> MyFriends { get; set; }
    }
}
