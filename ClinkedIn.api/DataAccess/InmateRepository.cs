using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.DataAccess
{
    public class InmateRepository
    {
        public Dictionary<string,List<Enemy>> Enemies {get; private set;}
        static List<Inmate> _inmates = new List<Inmate>
        {
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Nathan",
                Location = "Atlanta",
                CriminalInterest = CriminalInterest.Murder,
                ReleaseDate = new DateTime(2030, 04, 20),
                MyServices = new List<string>{"Phone calls", "Internet data", "Cash transfer"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Adam",
                Location = "Los Angeles",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2025, 06, 15),
                MyServices = new List<string>{"Extra food", "Plates", "Knives", "Forks"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Martin",
                Location = "New York",
                CriminalInterest = CriminalInterest.Assault,
                ReleaseDate = new DateTime(2050, 03, 05),
                MyServices = new List<string>{"Killing", "Ropes", "Belts", "Weapons"}
            },
            new Inmate
            {
                Id = Guid.NewGuid(),
                Name = "Greg",
                Location = "Boston",
                CriminalInterest = CriminalInterest.Robbery,
                ReleaseDate = new DateTime(2022, 08, 22),
                MyServices = new List<string>{"Alcohol", "Weed", "Cigarettes", "Drugs"}
            },

        };

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

        public List<string> GetAllFriends(string inmateName)
        {
            var inmate = _inmates.FirstOrDefault(clinker => clinker.Name == inmateName);
            return inmate.MyFriends;
        }

        public List<string> AddNewFriend(string newFriendName, string name)
        {
            var inmateAddingNewFriend = _inmates.FirstOrDefault(inmate => inmate.Name == name);
            inmateAddingNewFriend.MyFriends.Add(newFriendName);
            return inmateAddingNewFriend.MyFriends;
        }

        public Inmate Add(Inmate newInmate)
        {
            _inmates.Add(newInmate);

            return newInmate;
        }

        public List<Enemy> AddEnemy(Enemy enemy, string inmateName) 
        {
            if(!Enemies.ContainsKey(inmateName)) {
                Enemies.Add(inmateName, new List<Enemy>(){});
            }
            Enemies[inmateName].Add(enemy);
            return Enemies[inmateName]; 
        }

        public List<Enemy> GetAllEnemies(string name) {
            if(Enemies.TryGetValue(name,out List<Enemy> enemies)) {
                return enemies;
            }
            return null;
        }
    }
}
