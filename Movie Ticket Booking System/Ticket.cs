// remove unused using statement
using System;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    // Multiple Interfaces
    internal class Ticket : IPrintable , IBookable , ICloneable
    {
        private string movieName;
        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
                else
                    throw new ArgumentException("Movie name cannot be empty or whitespace");
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
                else
                    throw new ArgumentException("Price must be greater than 0");
            }
        }

        // Ticket ID
        public int TicketId { get; }

        // Static counter
        private static int ticketCounter = 0;

        // Constructor
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

        public bool IsBooked { get; private set; }

        public bool Book()
        {
            if (IsBooked)
                return false;

            IsBooked = true;
            return true;
        }

        public bool Cancel()
        {
            if (!IsBooked)
                return false;

            IsBooked = false;
            return true;
        }

        public virtual void Print()
        {
            string status = IsBooked ? "Booked" : "Available";

            Console.WriteLine(
                $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP | Status: {status}"
            );
        }

        public virtual object Clone() 
        {
            return new Ticket( movieName , price );
        }

        #endregion
    }
}
