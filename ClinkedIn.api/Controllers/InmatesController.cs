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

        [HttpGet("{inmateName}/services")]
        public ActionResult<List<string>> GetServicesByInmate(string inmateName)
        {
            var repo = new InmateRepository();
            var allServices = repo.GetServices(inmateName);
            return Ok(allServices);

        }

        [HttpPost("{inmateName}/services")]
        public IActionResult AddService(AddServiceCommand serviceToAdd, string inmateName)
        {
            var repo = new InmateRepository();

            repo.AddService(serviceToAdd.Service, inmateName);
            return Created($"api/inmates/{inmateName}/services/{serviceToAdd}", serviceToAdd);
            
        }
        
        // Returns all enemys for a given inmate
        [HttpGet("{inmateName}/allEnemys")]
        public ActionResult<IEnumerable<string>> GetEnemysByName(string inmateName)
        {
            var repo = new InmateRepository();
            var allEnemys = repo.GetAllEnemys(inmateName);
            return Ok(allEnemys);

        }

        // Start of AddEnemy 
        [HttpPost("{name}/enemys")]
        public IActionResult AddNewEnemy(AddEnemyCommand enemyToAdd, string name)
        {
            var repo = new InmateRepository();
            string enemyName = enemyToAdd.Name;
            var enemyCriminalInterest = enemyToAdd.CriminalInterest;

            repo.AddNewEnemy(enemyName, name);
            return Created($"api/inmates/{enemyToAdd.Name}", enemyToAdd);
        }

    }

}