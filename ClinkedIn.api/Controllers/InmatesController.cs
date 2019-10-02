using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
    }

    
}