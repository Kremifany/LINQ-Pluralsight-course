﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = ProcessCars("fuel.csv");
            var document = new XDocument();
            var cars = new XElement("Cars");
            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);
                cars.Add(car);
                cars.Add(name);
                cars.Add(combined);
            }
            document.Add(cars);
            document.Save("fuel.xml");
                
        }
        private static List<Car> ProcessCars(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();
           
            return query.ToList();
        }
    
        public class CarStatistics
        {
            public CarStatistics()
            {
                Max = Int32.MinValue;
                Min = Int32.MaxValue;
            }

            public  CarStatistics Accumulate(Car car)
            {
                Count += 1;
                Total += car.Combined;
                Max = Math.Max(Max, car.Combined);
                Min = Math.Min(Min, car.Combined);
                return this;
            }

            public CarStatistics Compute()
            {
                Average = Total / Count;
                return this;
            }

            public int Max { get; set; }
            public int Min { get; set; }
            public int Total { get; set; }
            public int Count { get; set; }
            public double Average { get; set; }
        }
        private static List<Manufacturer>ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                     {
                         var columns = l.Split(',');
                         return new Manufacturer
                         {
                             Name = columns[0],
                             Headquarters = columns[1],
                             Year = int.Parse(columns[2])
                         };
                     });

        return query.ToList();
        }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach(var line in source)
            {
                var columns = line.Split(',');
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
        
    }

}
