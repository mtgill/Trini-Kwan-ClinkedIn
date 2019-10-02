using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using ClinkedIn.Api.Commands;

namespace ClinkedIn.Api.Controllers
{
    [Route("api/inmates")]
    [ApiController]
    public class InmateController : Controller
    {
        [HttpGet("{criminalInterestToSearchFor}")]
        public ActionResult<IEnumerable<Inmate>> GetByCriminalInterest(CriminalInterest criminalInterestToSearchFor)
        {
            var inmateRepo = new InmateRepository();
            return inmateRepo.Get(criminalInterestToSearchFor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Inmate>> GetAllInmates()
        {
            var repo = new InmateRepository();

            return repo.GetAll();
        }

        [HttpPost]
        public IActionResult CreateInmate(AddInmateCommand newAddInmateCommand)
        {
            var newInmate = new Inmate
            {
                Id = Guid.NewGuid(),
                Name = newAddInmateCommand.Name,
                Location = newAddInmateCommand.Location,
                CriminalInterest = newAddInmateCommand.CriminalInterest,
                ReleaseDate = newAddInmateCommand.ReleaseDate,
            };

            var repo = new InmateRepository();

            var inmateThatGotCreated = repo.Add(newInmate);

            return Created($"api/inmates/{inmateThatGotCreated.Name}", inmateThatGotCreated);
        }

        // Returns all friends for a given inmate
        [HttpGet("{inmateName}/allFriends")]
        public ActionResult<IEnumerable<string>> GetFriendsByName(string inmateName)
        {
            var repo = new InmateRepository();
            var allFriends = repo.GetAllFriends(inmateName);
            return Ok(allFriends);

        }

        // Start of AddFriend 
        [HttpPost("{name}/friends")]
        public IActionResult AddNewFriend(AddFriendCommand friendToAdd, string name)
        {
            var repo = new InmateRepository();
            string friendName = friendToAdd.Name;
            var friendCriminalInterest = friendToAdd.CriminalInterest;

            repo.AddNewFriend(friendName, name);
            return Created($"api/inmates/{friendToAdd.Name}", friendToAdd);
        }

        [HttpPost("{name}/enemy")]
        public IActionResult AddNewEnemy(AddEnemyCommand enemyToAdd, string name) {
            var repo = new InmateRepository();
            var enemy = new Enemy() { Name = enemyToAdd.Name, Location = enemyToAdd.Location, ReleaseDate = enemyToAdd.ReleaseDate, Id = Guid.NewGuid() };
            repo.AddEnemy(enemy, name);
            return Created($"api/inmates/enemy/{enemyToAdd.Name}", enemyToAdd);
        }
        

        // Returns all enemies for a given inmate
        [HttpGet("{inmateName}/allEnemies")]
        public ActionResult<IEnumerable<string>> GetEnemyByName(string inmateName)
        {
            var repo = new InmateRepository();
            var allFriends = repo.GetListEnemy(inmateName);
            return Ok(allFriends);
        }


    }

    
}