using System;
using System.Collections.Generic;
using System.IO;

namespace TableReservationApp
{
    public class Reservation
    {
        public List<Restaurant> reservation;

        public Reservation()
        {
            reservation = new List<Restaurant>();
        }

        public void AddRestaurant(string name, int tableCount)
        {
            try
            {
                Restaurant restaurant = new Restaurant();
                restaurant.name = name;
                restaurant.table = new Table[tableCount];
                for (int i = 0; i < tableCount; i++)
                {
                    restaurant.table[i] = new Table();
                }
                reservation.Add(restaurant);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadRestaurantsFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int tableCount))
                    {
                        AddRestaurant(parts[0], tableCount);
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> FindFreeTables(DateTime date)
        {
            try
            {
                List<string> freeTables = new List<string>();
                foreach (var restaurant in reservation)
                {
                    for (int i = 0; i < restaurant.table.Length; i++)
                    {
                        if (!restaurant.table[i].IsBooked(date))
                        {
                            freeTables.Add($"{restaurant.name} - Table {i + 1}");
                        }
                    }
                }
                return freeTables;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<string>();
            }
        }

        public bool BookTable(string name, DateTime date, int tableNumber)
        {
            foreach (var restaurant in reservation)
            {
                if (restaurant.name == name)
                {
                    if (tableNumber < 0 || tableNumber >= restaurant.table.Length)
                    {
                        throw new Exception("Invalid table number");
                    }
                    return restaurant.table[tableNumber].Book(date);
                }
            }
            throw new Exception("Restaurant not found");
        }

        public void SortRestaurantsByAvailabilityForUsers(DateTime date)
        {
            try
            {
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < reservation.Count - 1; i++)
                    {
                        int availableTablesCurrent = CountAvailableTablesForRestaurantClassAndDateTime(reservation[i], date);
                        int availableTablesNext = CountAvailableTablesForRestaurantClassAndDateTime(reservation[i + 1], date);

                        if (availableTablesCurrent < availableTablesNext)
                        {
                            var temp = reservation[i];
                            reservation[i] = reservation[i + 1];
                            reservation[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int CountAvailableTablesForRestaurantClassAndDateTime(Restaurant restaurant, DateTime date)
        {
            try
            {
                int count = 0;
                foreach (var table in restaurant.table)
                {
                    if (!table.IsBooked(date))
                    {
                        count++;
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
