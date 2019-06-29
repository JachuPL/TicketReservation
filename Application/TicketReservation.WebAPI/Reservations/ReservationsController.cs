using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketReservation.Application.Reservations.Interfaces;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.WebAPI.Extensions;

namespace TicketReservation.WebAPI.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IQueryReservations _reservationQuerier;
        private readonly IManageReservations _reservationManager;

        public ReservationsController(IQueryReservations reservationQuerier, IManageReservations reservationManager)
        {
            _reservationQuerier = reservationQuerier;
            _reservationManager = reservationManager;
        }

        [Route("offer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReservationOffer>> GetOffer([FromQuery] ReservationOfferRequest model)
        {
            ReservationOffer offer = await _reservationQuerier.GetReservationOffer(model);
            return Ok(offer);
        }

        [HttpGet]
        [Route("{id:guid}", Name = nameof(GetReservationById))]
        public ActionResult GetReservationById(Guid id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(ReservationOffer model)
        {
            Guid reservationId = Guid.NewGuid();
            await _reservationManager.Add(reservationId, User.GetGuid(), model);

            return CreatedAtRoute(nameof(GetReservationById), new { id = reservationId }, reservationId);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _reservationManager.Delete(id);
            return NoContent();
        }
    }
}