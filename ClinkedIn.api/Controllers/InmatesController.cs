﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Api.Commands;
using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Api.Controllers
{
    public class InmateController : Controller
    {
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
    }
}