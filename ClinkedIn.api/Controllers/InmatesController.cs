using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClinkedIn.Api.Models;
using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Commands;

namespace ClinkedIn.Api.Controllers
{
    [Route("api/inmates")]
    [ApiController]
    public class InmateController : Controller
    {
        // Start of AddFriend 
        [HttpPost("{name}/friends")]
        public IActionResult AddNewFriend(AddFriendCommand friendToAdd, string name)
        {
            var repo = new InmateRepository();
            string friendName = friendToAdd.Name;
            var friendCriminalInterest = friendToAdd.CriminalInterest;

            repo.AddNewFriend(friendName, name);
            return Created($"api/inmates/{friendToAdd.Name}", friendToAdd);
            // return Ok();
        }
        
    }
}