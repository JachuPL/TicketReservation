using Microsoft.AspNetCore.Mvc;
using System;

namespace TicketReservation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [Route("offer")]
        [HttpGet]
        public ActionResult GetOffer(ReservationConfiguration model)
        {
            throw new Exception();
        }
    }
}