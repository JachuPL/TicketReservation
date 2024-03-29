﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketReservation.Application.Movies.Interfaces;
using TicketReservation.Application.Movies.Models;

namespace TicketReservation.WebAPI.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("{id:guid}", Name = nameof(GetMovieById))]
        public ActionResult GetMovieById(Guid id)
        {
            // NOTE: this was just defined only for route generation while POSTing new entity
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateMovieRequest model)
        {
            Guid movieId = Guid.NewGuid();
            await _movieService.Add(movieId, model);

            return CreatedAtRoute(nameof(GetMovieById), new { id = movieId }, movieId);
        }
    }
}