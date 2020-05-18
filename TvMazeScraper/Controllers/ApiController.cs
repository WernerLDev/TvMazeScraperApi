using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TvMazeScraper.Database;
using TvMazeScraper.Database.Models;
using TvMazeScraper.Repositories.interfaces;
using TvMazeScraper.services;

namespace TvMazeScraper.Controllers
{
    [Route("api/v1")]
    public class ApiController : Controller
    {
        private IShowService ShowService;

    public ApiController(IShowService showService)
    {
      ShowService = showService;
    }

    [HttpGet("shows")]
        public IActionResult Home([FromQuery] int? page, [FromQuery] int? perPage) {
            var result = ShowService.GetShows(page ?? 0, perPage ?? 10);
            return Ok(result);
        }
    }
}
