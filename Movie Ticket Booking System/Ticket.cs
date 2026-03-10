using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal class Ticket
    {
        private string movieName;
        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public SeatLocation Seat { get; set; }

        // Ticket ID
        public int TicketId { get; }

        // Static counter
        private static int ticketCounter = 0;

        // Constructor
        //public Ticket(string movieName,  SeatLocation seat, decimal price)
        //{
        //    ticketCounter++;
        //    TicketId = ticketCounter;

        //    MovieName = movieName;
        //    
        //    Seat = seat;
        //    Price = price;
        //}

        //b.A constructor that takes movieName and price.

        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            ticketCounter++;
            TicketId = ticketCounter;
        }

        public Ticket(string movieName)
        {
            ticketCounter++;
            TicketId = ticketCounter;
            MovieName = movieName;
        }

        // A computed property PriceAfterTax that returns the price with 14% tax.
        public decimal PriceAfterTax
        {
            get
            {
                return Price * 1.14m;
            }
        }

        // A static int GetTotalTickets() method that returns the total number of tickets created.
        public static int GetTotalTickets()
        {
            return ticketCounter;
        }

        // Override ToString() to return the ticket info.
        //public override string ToString()
        //{
        //    return $"Ticket #{TicketId} | {MovieName} | Seat: {Seat} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
        //}

        public override string ToString()
        {
            return $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
        }


        //1.Refactor the base Ticket class:

        //a.Add a PrintTicket() method that prints: TicketId, MovieName, Price, PriceAfterTax.
        //Child classes should be able to provide their own version of this method.

        // Virtual method for polymorphism
        public virtual void PrintTicket()
        {
            Console.WriteLine($"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP");
        }

        //b.Add two versions of a SetPrice method — one that takes a decimal (sets price directly)
        //and one that takes a decimal base price and a decimal multiplier(sets price = base × multiplier).

        // Method Overloading
        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public void SetPrice(decimal basePrice, decimal multiplier)
        {
            Price = basePrice * multiplier;
        }

        #region Assignment 05
        #endregion
    }
}
