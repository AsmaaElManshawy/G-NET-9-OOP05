using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal class IMAXTicket : Ticket
    {
        //2. Create three child classes that inherit from Ticket:
        //c.IMAXTicket — adds Is3D(bool). If true, the price increases by 30 EGP.
        //Each child class should override ToString() to include its own extra info.

        public bool Is3D { get; set; }

        public IMAXTicket(string movieName, decimal price, bool is3D) : base(movieName, is3D ? price + 30m : price)
        {
            Is3D = is3D;
        }

        public IMAXTicket(string movieName, bool is3D) : base(movieName)
        {
            Is3D = is3D;
        }

        public override string ToString()
        {
            string type = Is3D ? "Yes" : "No";
            return base.ToString() + $" | IMAX 3D: {type}";
        }

        //2. In each child class, provide its own version of PrintTicket():
        //c.IMAXTicket — prints the base ticket info and whether it is 3D.

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"IMAX 3D: {(Is3D ? "Yes" : "No")}");
        }

        #region Assignment 05
        #endregion

    }
}
