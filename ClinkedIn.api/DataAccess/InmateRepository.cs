using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.Commands;
using System.Collections;

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
                MyServices = new List<string>{"Phone calls", "Internet data", "Cash transfer"},
                MyFriends = new List<string>{"Adam", "Martin", "Emily"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Adam",
                Location = "Los Angeles",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2025, 06, 15),
                MyServices = new List<string>{"Extra food", "Plates", "Knives", "Forks"},
                MyFriends = new List<string>{"Nathan", "Greg", "Matt"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Martin",
                Location = "New York",
                CriminalInterest = CriminalInterest.Assault,
                ReleaseDate = new DateTime(2050, 03, 05),
                MyServices = new List<string>{"Killing", "Ropes", "Belts", "Weapons"},
                MyFriends = new List<string>{"Mark", "Nathan", "Matt"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Greg",
                Location = "Boston",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2022, 08, 22),
                MyServices = new List<string>{"Alcohol", "Weed", "Cigarettes", "Drugs"},
                MyFriends = new List<string>{"Adam", "Martin", "Nathan", "Mark", "Emily"}
            },

        };

<<<<<<< HEAD
        internal ActionResult<int> GetDaysUntilRelease(string name)
        {
            var inmate = _inmates.FirstOrDefault(clinker => clinker.Name == name);

            DateTime releaseDate = inmate.ReleaseDate;
            TimeSpan daysUntilRelease = releaseDate - DateTime.Today;

            return daysUntilRelease.Days;
        }
=======
>>>>>>> master

        public List<Inmate> Get(CriminalInterest criminalInterestToSearchFor)
        {
            var inmates = _inmates.FindAll(interest => interest.CriminalInterest == criminalInterestToSearchFor);
            return inmates;
        }

        public List<Inmate> GetAll()
        {
            return _inmates;
        }

        public Inmate Get(string name)
        {
            var inmate = _inmates.FirstOrDefault(t => t.Name == name);
            return inmate;
        }

        //This functions loops through the inmates field and searches for the friend,
        //then it returns a list of that friend's friends
        internal List<IEnumerable> GetFriends(string friendName)
        {
            var friendFriends = new List<IEnumerable>();
           foreach( var inmate in _inmates)
            {
                foreach(var friend in inmate.MyFriends)
                {
                    if (inmate.MyFriends.Contains(friendName))
                    {
                        var myFriendFriends = _inmates.Where(s => s.Name == friendName).Select(z => z.MyFriends);
                        friendFriends.Add(myFriendFriends);
                        break;
                    }
                    break;
                }
                break;
            }
            return friendFriends;
        }

        public List<string> GetAllFriends(string inmateName)
        {
            var inmate = _inmates.FirstOrDefault(clinker => clinker.Name == inmateName);
            return inmate.MyFriends;
        }

        public List<string> GetServices(string inmateName)
        {
            var inmate = _inmates.FirstOrDefault(person => person.Name == inmateName);
            return inmate.MyServices;

        }

        public List<string> AddNewFriend(string newFriendName, string name)
        {
            var inmateAddingNewFriend = _inmates.FirstOrDefault(inmate => inmate.Name == name);
            inmateAddingNewFriend.MyFriends.Add(newFriendName);
            return inmateAddingNewFriend.MyFriends;
        }

        public List<string> AddService(string newService, string inmateName)
        {
            var inmateAddingService = _inmates.FirstOrDefault(inmate => inmate.Name == inmateName);
            inmateAddingService.MyServices.Add(newService);
            return inmateAddingService.MyServices;
        }

        public Inmate Add(Inmate newInmate)
        {
            _inmates.Add(newInmate);

            return newInmate;
        }


        ///get all enemys

        public List<string> GetAllEnemys(string inmateName)
        {
            var inmate = _inmates.FirstOrDefault(clinker => clinker.Name == inmateName);
            return inmate.MyEnemys;
        }

        public List<string> AddNewEnemy(string newEnemyName, string name)
        {
            var inmateAddingNewEnemy = _inmates.FirstOrDefault(inmate => inmate.Name == name);
            inmateAddingNewEnemy.MyEnemys.Add(newEnemyName);
            return inmateAddingNewEnemy.MyEnemys;
        }

    }
}
