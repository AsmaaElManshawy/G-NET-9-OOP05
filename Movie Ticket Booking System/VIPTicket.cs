using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal sealed class VIPTicket : Ticket
    {
        //2. Create three child classes that inherit from Ticket:
        //b.VIPTicket — adds LoungeAccess(bool) and ServiceFee(decimal) = 50.
        //Each child class should override ToString() to include its own extra info.

        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; } = 50m;

        public VIPTicket(string movieName, decimal price, bool loungeAccess) : base(movieName, price + 50m)
        {
            LoungeAccess = loungeAccess;
        }

        public VIPTicket(string movieName, bool loungeAccess, decimal fee) : base(movieName)
        {
            LoungeAccess = loungeAccess;
            ServiceFee = fee;
        }

        public override string ToString()
        {
            string lounge = LoungeAccess ? "Yes" : "No";
            return base.ToString() + $" | Lounge: {lounge} | Service Fee: {ServiceFee} EGP";
        }


        //2. In each child class, provide its own version of PrintTicket():
        //b.VIPTicket — prints the base ticket info, LoungeAccess, and ServiceFee.

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"Lounge: {(LoungeAccess ? "Yes" : "No")} | Service Fee: {ServiceFee} EGP");
        }

        #region Assignment 05
        #endregion

    }
}
