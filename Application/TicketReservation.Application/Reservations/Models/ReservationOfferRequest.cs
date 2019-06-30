using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketReservation.Application.Reservations.Models
{
    public class ReservationOfferRequest
    {
        public Guid ShowId { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            ReservationOfferRequest other = obj as ReservationOfferRequest;
            if (other is null)
                return false;

            return ShowId == other.ShowId
                && PlacesAreEqual(other.Places);
        }

        private bool PlacesAreEqual(List<Place> places)
        {
            foreach (var place in places)
            {
                if (!Places.Any(x => place.Equals(x))) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ShowId.GetHashCode() * Places.GetHashCode()) ^ 1337;
            }
        }
    }
}