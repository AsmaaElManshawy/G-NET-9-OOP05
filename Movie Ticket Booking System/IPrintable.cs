// remove unused using statement
using System;

namespace Assignment_5.Movie_Ticket_Booking_System
{
    internal interface IPrintable
    {
        //=========================================
        //1. Unified Printing — The manager noticed that different parts of the system print ticket info in different ways.
        //He wants a standard contract that guarantees any printable object in the system (tickets, receipts, etc.)
        //can print itself through a single common method.
        //All ticket types (Standard, VIP, IMAX) should follow this contract,
        //and each one should print its own specific details.
        //
        //The Cinema should also be able to print all its tickets using this contract.
        //There should also be a utility method in BookingHelper that can accept an array of any printable objects
        //and print them all — without knowing their actual types.
        //=========================================
        void Print();
    }
}
