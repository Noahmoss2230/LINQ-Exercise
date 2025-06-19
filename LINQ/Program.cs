using System.Globalization;

namespace LINQ
{
    class Program
    {
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");

            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("--------------------");
            Console.WriteLine("Asc");

            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }

            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("--------------------");
            Console.WriteLine("Desc");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            var greaterThanSix = numbers.Where(num => num > 6);

            Console.WriteLine("Greater than Six");
            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            var firstFour = asc.Take(4);
            Console.WriteLine("First 4 asc");
            foreach (var num in firstFour)
            {
                Console.WriteLine(num);
            }

            numbers[4] = 32;
            Console.WriteLine("With my age:");
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            var employees = CreateEmployees();

            var filtered = 
                employees.Where(emp => emp.FirstName.StartsWith('C') || emp.FirstName.StartsWith('S')).OrderBy(emp => emp.FirstName);
            
            Console.WriteLine("C or S Employees:");
            foreach (var emp in filtered)
            {
                Console.WriteLine(emp.FullName);
            }

            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName)
                .ThenBy(emp => emp.YearsOfExperience);

            Console.WriteLine("Over 26");
            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"Fullname: {employee.FullName} Age: {employee.Age} YOE: {employee.YearsOfExperience}");
            }

            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);
            
            Console.WriteLine($"Sum {sumOfYOE} Avg {avgOfYOE}");
            
            employees = employees.Append(new Employee("first", "last", 98, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }
            

            Console.WriteLine();
            Console.ReadLine();
        }

        #region CreateEmployeeMethod

        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Michael", "Doyle", 36, 8));
            employees.Add(new Employee("Jake", "The Snake", 22, 2));
            employees.Add(new Employee("Chris P.", "Bacon", 29, 7));
            employees.Add(new Employee("Jill", "Valentine", 41, 16));
            
            return employees;
        }
    



    #endregion
    }
}
