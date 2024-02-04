using System;
using System.Collections.Generic;
using System.IO;

namespace TableReservationApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Reservation manager = new Reservation();
            manager.AddRestaurant("A", 10);
            manager.AddRestaurant("B", 5);

            Console.WriteLine(manager.BookTable("A", new DateTime(2023, 12, 25), 3));
            Console.WriteLine(manager.BookTable("A", new DateTime(2023, 12, 25), 3));

        }
    }
}