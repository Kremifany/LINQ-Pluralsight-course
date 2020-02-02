using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)

        { 

            Func<int, int> square = x => x * x;
            Console.WriteLine(square(3));
            Console.WriteLine("+++++++++");

            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(square(add(3,5)));

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name= "Scott" },
                new Employee {Id = 2, Name = "Chris" },
                new Employee {Id = 3, Name = "Alexa"}
            };
            Console.WriteLine("+++++++++");
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 3, Name = "Alex"}
            };

            Console.WriteLine(developers.Count());
            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            Console.WriteLine("+++++++++");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("+++++++++");
            foreach (var employee in developers.Where(
                e => e.Name.StartsWith("C")))
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine("+++++++++");
            
            //method syntax
            var query1 = developers.Where(e => e.Name.Length == 5)
                                   .OrderByDescending(e => e.Name)
                                   .Select(e => e);

            Console.WriteLine("+++++++++");

            //query syntax
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name descending
                         select developer;                         ;

            foreach (var employee in query1)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
