using System;
using System.Collections.Generic;
using System.IO;

namespace TableReservationApp
{
    public class Table
    {
        private List<DateTime> bookedDates;

        public Table()
        {
            bookedDates = new List<DateTime>();
        }

        public bool Book(DateTime date)
        {
            try
            {
                if (bookedDates.Contains(date))
                {
                    return false;
                }

                bookedDates.Add(date);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool IsBooked(DateTime date)
        {
            return bookedDates.Contains(date);
        }
    }
}
