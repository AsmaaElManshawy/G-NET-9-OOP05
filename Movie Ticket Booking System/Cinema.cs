using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal class Cinema
    {
        //3. Create a Cinema class
        // Private array to hold tickets
        //private Ticket[] tickets = new Ticket[20];

        public string CinemaName { get; set; }

        private Projector projector = new Projector(); // Composition
        private Ticket[] tickets = new Ticket[20];

        public Cinema(string name)
        {
            CinemaName = name;
        }

        // Indexer
        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                    return tickets[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < tickets.Length)
                    tickets[index] = value;
            }
        }
        // Get Movie By Name
        public Ticket GetMovieByName(string movieName)
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null && ticket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return ticket;
            }
            return null;
        }
        // Add Ticket
        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            Console.WriteLine("Cinema is full!");
            return false;
        }

        //b.PrintAllTickets() — prints all tickets.
        //Assignment 04 - 3. In the Cinema class, update PrintAllTickets() so it loops through the Ticket[] array
        //and calls PrintTicket() on each one.
        public void PrintAllTickets()
        {
            Console.WriteLine("\n========== All Tickets ==========\n");

            foreach (var t in tickets)
            {
                if (t != null)
                {
                    t.PrintTicket();
                }
            }
        }

        //c.OpenCinema() and CloseCinema() — start/stop the projector.

        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine("\n========== Cinema Closed ==========");
            projector.Stop();
        }


        //4. Create a static method ProcessTicket(Ticket t) that takes any Ticket and calls PrintTicket() on it.

        public static void ProcessTicket(Ticket t)
        {
            Console.WriteLine("\n========== Process Single Ticket ==========");
            t.PrintTicket();
        }

        #region Assignment 05
        #endregion

    }
}
