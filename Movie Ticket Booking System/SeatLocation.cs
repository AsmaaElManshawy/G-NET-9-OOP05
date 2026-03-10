using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal struct SeatLocation
    {
        public char Row { get; set; }
        public int Number { get; set; }

        public SeatLocation(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Row}-{Number}";
        }

    }
}
