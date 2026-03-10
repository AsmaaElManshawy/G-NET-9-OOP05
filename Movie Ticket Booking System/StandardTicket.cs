// remove unused using statement
using System;


namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal class StandardTicket : Ticket
    {
        //2. Create three child classes that inherit from Ticket:
        //a.StandardTicket — adds SeatNumber(string).
        //Each child class should override ToString() to include its own extra info.

        public string SeatNumber { get; set; }

        public StandardTicket(string movieName, decimal price, string seatNumber) : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }

        public StandardTicket(string movieName, string seat) : base(movieName)
        {
            SeatNumber = seat;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Seat: {SeatNumber}";
        }


        //2. In each child class, provide its own version of PrintTicket():
        //a.StandardTicket — prints the base ticket info and the SeatNumber.

        #region Assignment 05

        public override void Print()
        {
            Console.WriteLine($"[Ticket #{TicketId}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}");
        }

        public override object Clone()
        {
            return new StandardTicket(MovieName, Price, SeatNumber);
        }

        #endregion

    }
}
