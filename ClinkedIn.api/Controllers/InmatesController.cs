using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.Commands;
using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Api.Controllers
{
    [Route("api/inmates")]
    [ApiController]
    public class InmateController : Controller
    {
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

        [HttpPost("{inmateName}/services")]
        public IActionResult AddService(AddServiceCommand serviceToAdd, string inmateName)
        {
            var repo = new InmateRepository();
            
        }
        
    }
}