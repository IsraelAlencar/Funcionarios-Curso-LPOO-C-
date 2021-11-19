using System;
using System.Globalization;
using System.Collections.Generic;
using Funcionario.Entities;

namespace Funcionario {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Employee #1 data:");

                Console.Write("Outsourced (y/n)? ");
                string origin = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (origin == "n") {
                    employees.Add(new Employee(name, hours, valuePerHour));
                }

                else if (origin == "y") {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employees.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
            }

            Console.WriteLine();

            Console.WriteLine("PAYMENTS:");
            foreach (Employee emp in employees) {
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
