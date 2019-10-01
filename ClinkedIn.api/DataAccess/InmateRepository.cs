﻿using ClinkedIn.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.Models;

namespace ClinkedIn.Api.DataAccess
{
    public class InmateRepository
    {
        static List<Inmate> _inmates = new List<Inmate>
        {
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Nathan",
                Location = "Atlanta",
                CriminalInterest = CriminalInterest.Murder,
                ReleaseDate = new DateTime(2030, 04, 20),
                MyServices = new List<string>{"Phone calls"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Adam",
                Location = "Los Angeles",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2025, 06, 15),
                MyServices = new List<string>{"Extra food"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Martin",
                Location = "New York",
                CriminalInterest = CriminalInterest.Assault,
                ReleaseDate = new DateTime(2050, 03, 05),
                MyServices = new List<string>{"Killing"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Greg",
                Location = "Boston",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2022, 08, 22),
                MyServices = new List<string>{"Alcohol"}
            },

        };

        public List<string> AddNewFriend(string newFriendName, Guid id)
        {
            var inmateAddingNewFriend = _inmates.FirstOrDefault(inmate => inmate.Id == id);
            inmateAddingNewFriend.MyFriends.Add(newFriendName);
            return inmateAddingNewFriend.MyFriends;
        }

        public Inmate Add(Inmate newInmate)
        {
            _inmates.Add(newInmate);

            return newInmate;
        }
    }
}
