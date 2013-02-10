/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 3: A company has name, address, phone number, fax number,
 * web site and manager. The manager has first name, last name,
 * age and a phone number. Write a program that reads the information
 * about a company and its manager and prints them on the console.
 * 
 */

using System;

namespace CompanyInfo
{
    class CompanyInfo
    {
        public class Worker
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public byte Age { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class Company
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string FaxNumber { get; set; }
            public string Website { get; set; }
            public Worker Manager { get; set; }
        }

        static void Main()
        {
            Console.WriteLine("Company information");
            Company company = new Company();

            Console.Write("Company name: ");
            company.Name = Console.ReadLine();

            Console.Write("Company address: ");
            company.Address = Console.ReadLine();

            Console.Write("Company phone number: ");
            company.PhoneNumber = Console.ReadLine();

            Console.Write("Company fax number: ");
            company.FaxNumber = Console.ReadLine();

            Console.Write("Company website: ");
            company.FaxNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Manager information");
            company.Manager = new Worker();

             Console.Write("Manager first name: ");
            company.Manager.FirstName = Console.ReadLine();

            Console.Write("Manager last name: ");
            company.Manager.LastName = Console.ReadLine();

            Console.Write("Manager age: ");
            company.Manager.Age = byte.Parse(Console.ReadLine());

            Console.Write("Manager phone number: ");
            company.Manager.PhoneNumber = Console.ReadLine();
        }
    }
}
