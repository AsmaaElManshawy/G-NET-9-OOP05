using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal static class BookingHelper
    {
        // Private static counter for generating unique booking references
        private static int bookingCounter = 0;
        // a. Calculate group discount
        public static decimal CalcGroupDiscount(int numberOfTickets, decimal pricePerTicket)
        {
            decimal total = numberOfTickets * pricePerTicket;

            if (numberOfTickets >= 5)
                return total * 0.9m; // 10% discount

            return total;
        }
        // b. Generate unique booking reference
        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }
    }
}
