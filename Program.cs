using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n" + new string('-', 70) + "\n");
            Console.WriteLine("Assignment 05 OOP");
            Console.WriteLine("\n" + new string('-',70) + "\n");


            #region Part 01 : Theoretical Questions

            #region Question 1

            //----------------------
            //Q1: What is an interface in C#?
            //----------------------

            // is a contract that defines a set of methods, properties, or events that a class must implement.
            // It does not contain implementation, only method signatures.

            //----------------------
            //Why do we use interfaces instead of depending on concrete classes directly?
            //Mention at least three benefits of using interfaces.
            //---------------------

            // Loose Coupling :
            // Code depends on the interface, not a specific class.
            // This makes the system easier to change and maintain.

            // Polymorphism :
            // Multiple classes can implement the same interface and be used interchangeably.

            //Better Testability: 
            //Interfaces allow mock implementations for unit testing.

            //Extensibility :
            //New implementations can be added without modifying existing code.

            #endregion

            #region Question 2

            //Q2 : Look at the following code and answer the questions below:

            //interface IEnglishSpeaker
            //        {
            //            void Greet();
            //        }

            //        interface IArabicSpeaker
            //        {
            //            void Greet();
            //        }

            //        class Translator : IEnglishSpeaker, IArabicSpeaker
            //        {
            //            public void Greet()
            //            {
            //                Console.WriteLine("Hello / Ahlan");
            //            }
            //        }
            //----------------------
            //a) What is the problem with this design?
            //Both interfaces have a method called Greet() — how does the class handle it currently?
            //----------------------
            // Both interfaces contain a method with the same name: void Greet()
            // The Translator class implements one method so both interfaces use the same implementation,
            // meaning the class cannot provide different behavior for each interface.

            //----------------------
            //b) How would you fix this so IEnglishSpeaker.Greet() says "Hello" and
            //IArabicSpeaker.Greet() says "Ahlan"?
            //What is this technique called?
            //----------------------

            // Fixed:
            //       class Translator : IEnglishSpeaker, IArabicSpeaker
            //       {
            //           void IEnglishSpeaker.Greet()
            //           {
            //               Console.WriteLine("Hello");
            //           }
            //       
            //           void IArabicSpeaker.Greet()
            //           {
            //               Console.WriteLine("Ahlan");
            //           }
            //       }

            // This technique is called: Explicit Interface Implementation
            // It allows a class to implement multiple interfaces with methods that have the same name.

            //----------------------
            //c) After applying your fix, can you call Greet() directly on a Translator object (e.g.translator.Greet())?
            //Why or why not? How do you call each version?
            //----------------------

            //No, Because the methods are implemented explicitly, they are not accessible through the class itself.
            //They must be called using the interface reference.
            // Callling : 
            //   IEnglishSpeaker eng = new Translator();
            //   eng.Greet();
            //   
            //   IArabicSpeaker ar = new Translator();
            //   ar.Greet();
            // OR
            //   Translator translator = new Translator();

            //   ((IEnglishSpeaker)translator).Greet(); // Hello
            //   ((IArabicSpeaker)translator).Greet();  // Ahlan
            // OR
            // IEnglishSpeaker eng =  translator;
            // IArabicSpeaker arb =  translator;

            //   eng.Greet();
            //   arb.Greet();

            #endregion

            #region Question 3

            //----------------------
            //Q3 : Explain the difference between a shallow copy and a deep copy.
            //----------------------

            //Shallow Copy
            //A shallow copy creates a new object but copies references of reference - type fields instead of duplicating them.
            // Value types -> copied
            // Reference types -> same reference

            // Deep Copy
            // A deep copy duplicates both the object and all referenced objects.

            //-------------------------
            //When would you use each one?
            //-------------------------

            // Shallow Copy : 

            //    When objects do not contain reference - type fields
            //    When shared references are acceptable     
            //    Faster and simpler 

            //Deep Copy : 

            //    When objects contain nested reference objects
            //    When you want complete independence between objects

            //----------------------
            //What is the risk of using a shallow copy when the object has reference-type fields?
            //----------------------

            // If the object contains reference-type fields, both objects will point to the same referenced object.
            // So modifying the nested object in one copy will affect the other object.

            #endregion

            #region Question 4

            //----------------------
            //Q4 : Look at the following code and determine the output.Explain why.
            //----------------------
            //    class Department { public string Name; }
            //    class Employee
            //    {
            //        public string Title;
            //        public Department Dept;
            //        public Employee ShallowCopy() => (Employee)this.MemberwiseClone();
            //    }

            //  var e1 = new Employee { Title = "Dev", Dept = new Department { Name = "IT" } };
            //  var e2 = e1.ShallowCopy();
            //  e2.Title = "QA";  // only e2 changes new string created
            //  e2.Dept.Name = "Testing";  // affects both

            //Console.WriteLine($"{e1.Title} - {e1.Dept.Name}");
            //Console.WriteLine($"{e2.Title} - {e2.Dept.Name}");
            //----------------------
            // output :
            //-----------
            // Dev - Testing
            // QA - Testing
            //---------------
            // Explanation :
            //---------------
            // it's a ShallowCopy so Value types -> copied , immutable types -> copied , Reference types -> same reference so
            // Title is separate for each object.
            // Dept is shared, so changing Dept.Name in e2 also changes it for e1.

            #endregion

            #endregion

            #region Part 02 : Practical(Extending the Movie Ticket Booking System)

            //--------------------
            //In the previous assignments, you built a Movie Ticket Booking System with inheritance,
            //polymorphism, and a Cinema class. Now you will refactor and extend the system using interfaces and object copying.
            //--------------------
            //User Story :
            //--------------------
            //The cinema manager wants to add three new capabilities to the booking system:
            //--------------------
            //1. Unified Printing — The manager noticed that different parts of the system print ticket info in different ways.
            //He wants a standard contract that guarantees any printable object in the system (tickets, receipts, etc.)
            //can print itself through a single common method.
            //All ticket types (Standard, VIP, IMAX) should follow this contract,
            //and each one should print its own specific details.
            //The Cinema should also be able to print all its tickets using this contract.
            //There should also be a utility method in BookingHelper that can accept an array of any printable objects
            //and print them all — without knowing their actual types.
            //--------------------
            //2. Booking & Cancellation — Right now, tickets are created but there is no way to track
            //whether a ticket is actually booked or cancelled. The manager wants every ticket to support
            //booking and cancellation operations.A ticket can only be booked once
            //(trying to book an already-booked ticket should fail),
            //and can only be cancelled if it is currently booked (trying to cancel a non-booked ticket should fail).
            //The booking status should appear when the ticket is printed.
            //--------------------
            //3. Ticket Cloning — Sometimes a customer wants to buy a second ticket with
            //the exact same details as an existing one but for a different movie.
            //The system should be able to create a full independent copy of any ticket (especially VIP tickets).
            //Changing anything on the copy must NOT affect the original ticket.
            //--------------------
            //Requirements :
            //--------------------
            //Use interfaces to implement each feature above.
            //Think about which standard C# interfaces (like ICloneable) can help you,
            //and which custom interfaces you need to create yourself.
            //--------------------
            //Your solution must demonstrate the following concepts from this session:
            //• Defining and implementing custom interfaces
            //• A class implementing multiple interfaces
            //• Using an interface as a method parameter(interface polymorphism)
            //• Implementing ICloneable for deep copying
            //• Proving that the cloned object is fully independent from the original
            //--------------------


            #region Main

            //In Main, demonstrate :

            //a.Create a Cinema and open it.
            //b.Create one of each ticket type with hardcoded data. Book all three and add them to the Cinema.
            //c.Print all tickets through the Cinema.
            //d.Clone a VIP ticket, change the clone's movie name, and print both to prove independence.
            //e.Cancel one ticket and reprint it to show the updated status.
            //f.Use the utility method to print an array of printable tickets.
            //g.Close the Cinema.
            //--------------------
            //Expected Output (Example) :

            //=== Cinema Opened ===

            //--- All Tickets ---
            //[Ticket #1] Inception | Standard | Seat: A5 | Price: 80 | After Tax: 91.2 | Booked: Yes
            //[Ticket #2] Avengers | VIP | Lounge: Yes | Fee: 50 | Price: 200 | After Tax: 228 | Booked: Yes
            //[Ticket #3] Dune | IMAX | 3D: Yes | Price: 130 | After Tax: 148.2 | Booked: Yes

            //--- Clone Test ---
            //Original : [Ticket #2] Avengers | VIP | Lounge: Yes | Fee: 50 | Price: 200 | After Tax: 228 | Booked: Yes
            //Clone    : [Ticket #4] Interstellar | VIP | Lounge: Yes | Fee: 50 | Price: 200 | After Tax: 228 | Booked: No

            //--- After Cancellation ---
            //[Ticket #1] Inception | Standard | Seat: A5 | Price: 80 | After Tax: 91.2 | Booked: No

            //--- BookingHelper.PrintAll ---
            //[Ticket #1] Inception | Standard | Seat: A5 | Price: 80 | After Tax: 91.2 | Booked: No
            //[Ticket #2] Avengers | VIP | Lounge: Yes | Fee: 50 | Price: 200 | After Tax: 228 | Booked: Yes
            //[Ticket #3] Dune | IMAX | 3D: Yes | Price: 130 | After Tax: 148.2 | Booked: Yes

            //=== Cinema Closed ===
            //--------------------


            #endregion

            #endregion

            Console.WriteLine("\n" + new string('-', 70) + "\n");
        }
    }
}
