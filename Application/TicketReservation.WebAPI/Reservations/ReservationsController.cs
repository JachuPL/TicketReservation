using Microsoft.AspNetCore.Mvc;
using System;
using TicketReservation.WebAPI.Reservations.Requests;

namespace TicketReservation.WebAPI.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        [Route("offer")]
        [HttpGet]
        public ActionResult GetOffer(ReserveTicketsRequest model)
        {
            throw new Exception();
        }
    }
}