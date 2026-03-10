// remove unused using statement
using System;


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

        public VIPTicket(string movieName, bool loungeAccess) : base(movieName)
        {
            LoungeAccess = loungeAccess;
        }

        public override string ToString()
        {
            string lounge = LoungeAccess ? "Yes" : "No";
            return base.ToString() + $" | Lounge: {lounge} | Service Fee: {ServiceFee} EGP";
        }

        #region Assignment 05
        
        public override void Print()
        {
            Console.WriteLine($"[Ticket #{TicketId}] {MovieName} | VIP | Lounge: {(LoungeAccess ? "Yes" : "No")} | Fee: {ServiceFee} | Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}");
        }
        
        public override object Clone()
        {
            return new VIPTicket(MovieName, Price - 50m , LoungeAccess);        
        }

        #endregion

    }
}
