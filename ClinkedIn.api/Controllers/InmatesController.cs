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
        [HttpPost("{id}")]
        public IActionResult AddNewFriend(AddFriendCommand friendToAdd, Guid id)
        {
            var repo = new InmateRepository();
            string friendName = friendToAdd.Name;
            var friendCriminalInterest = friendToAdd.CriminalInterest;

            repo.AddNewFriend(friendName, id);
            return Ok();
        }
        
    }
}