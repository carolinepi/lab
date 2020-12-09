using CompanyStructLib.Implementations;
using CompanyStructLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            var consoleModelCreation = new ConsoleModelCreation();

            var consoleCompany = new ConsoleCompany(company, consoleModelCreation);

            consoleCompany.Run();

        }
    }
}
