using CompanyStructLib.Implementations;
using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsoleCompany
    {
        private readonly Company company;
        private readonly ConsoleModelCreation modelCreation;
        private SaleManager saleManager;
        private DeliveryManager deliveryManager;
        private Director director;
        private DeliveryWorker workerA;
        private DeliveryWorker workerB;
        private SaleWorker workerX;
        private SaleWorker workerY;
        private IVisitor visitor = new SubordinateVisitor();
        public ConsoleCompany(Company company, ConsoleModelCreation consoleModelCreation)
        {
            this.company = company;
            modelCreation = consoleModelCreation;
        }
        private const string menu = "\n\t1     - Add director and subordinate!" +
    "\n\t2     - Add SaleManager and subordinate!" +
    "\n\t3     - Add DeliveryManager and subordinate" +
    "\n\t4     - Add WorkerA!" +
    "\n\t5     - Add WorkerB!" +
    "\n\t6     - Add WorkerX!" +
    "\n\t7     - Add WorkerY!" +
    "\n\t8     - Add All Employee!" +
    "\n\t9     - GetStructure!" +
    "\n\t10    - Change to DirectHierarchyStrategy" +
    "\n\t11    - Change to PositionalHierarchyStrategy" +
    "\n\t12    - Get Delivery Workers" +
    "\n\t13    - Get Sale Workers" +
    "\n\t14    - Get Big Wage" +
    "\n\t15    - Get Employee by Wage" +
    "\n\t0  - exit\n";
        public void Run()
        {
            Console.WriteLine("Choose action?");
            int answer = -1;

            while (answer != 0)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine(menu);

                answer = Answer();

                switch (answer)
                {
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    case 1:
                        Console.WriteLine("Add director and subordinate!");
                        director = modelCreation.AddDirector;
                        modelCreation.AddSubordinateForDirector(director, saleManager);
                        modelCreation.AddSubordinateForDirector(director, deliveryManager);
                        director.AcceptVisitor(visitor);
                        Console.WriteLine(director.Name + " " + director.Position + " " + director.Wage);
                        break;
                    case 2:
                        Console.WriteLine("Add SaleManager and subordinate!");
                        saleManager = modelCreation.AddSaleManager;
                        modelCreation.AddSubordinateForSaleManager(saleManager, workerX);
                        modelCreation.AddSubordinateForSaleManager(saleManager, workerY);
                        Console.WriteLine(saleManager.Name + " " + saleManager.Position + " " + saleManager.Wage);
                        break;
                    case 3:
                        Console.WriteLine("Add DeliveryManager and subordinate!");
                        deliveryManager = modelCreation.AddDeliveryManager;
                        modelCreation.AddSubordinateForDeliveryManager(deliveryManager, workerA);
                        modelCreation.AddSubordinateForDeliveryManager(deliveryManager, workerB);
                        Console.WriteLine(deliveryManager.Name + " " + deliveryManager.Position + " " + deliveryManager.Wage);
                        break;
                    case 4:
                        Console.WriteLine("Add WorkerA!");
                        workerA = modelCreation.AddWorkerA;
                        Console.WriteLine(workerA.Name + " " + workerA.Position + " " + workerA.Wage);
                        break;
                    case 5:
                        Console.WriteLine("Add WorkerB!");
                        workerB = modelCreation.AddWorkerB;
                        Console.WriteLine(workerB.Name + " " + workerB.Position + " " + workerB.Wage);

                        break;
                    case 6:
                        Console.WriteLine("Add WorkerX!");
                        workerX = modelCreation.AddWorkerX;
                        Console.WriteLine(workerX.Name + " " + workerX.Position + " " + workerX.Wage);

                        break;
                    case 7:
                        Console.WriteLine("Add WorkerY!");
                        workerY = modelCreation.AddWorkerY;
                        Console.WriteLine(workerY.Name + " " + workerY.Position + " " + workerY.Wage);

                        break;
                    case 8:
                        Console.WriteLine("Add All Employee!");
                        company.SetHierarchyStrategy(new PositionalHierarchyStrategy());
                        company.AddEmployee(workerA);
                        company.AddEmployee(workerB);
                        company.AddEmployee(saleManager);
                        company.AddEmployee(workerX);
                        company.AddEmployee(deliveryManager);
                        company.AddEmployee(workerY);
                        company.AddEmployee(director);
                        company.GetByWage(120);
                        break;
                    case 9:
                        Console.WriteLine("GetStructure!");
                        var result = company.GetStructure();
                        foreach (var r in result)
                        {
                            Console.WriteLine($"{r.Position}\n");
                        }
                        Console.WriteLine("=======================");
                        break;
                    case 10:
                        Console.WriteLine("Change to DirectHierarchyStrategy!");
                        company.SetHierarchyStrategy(new DirectHierarchyStrategy());
                        break;
                    case 11:
                        Console.WriteLine("Change to PositionalHierarchyStrategy!");
                        company.SetHierarchyStrategy(new PositionalHierarchyStrategy());
                        break;
                    case 12:
                        Console.WriteLine("Get Delivery Workers");
                        modelCreation.GetDeliveryManager();
                        break;
                    case 13:
                        Console.WriteLine("Get Sale Workers");
                        modelCreation.GetSaleManager();
                        break;
                    case 14:
                        Console.WriteLine("Get Big Wage");
                        modelCreation.GetBigWage();
                        break;
                    case 15:
                        Console.WriteLine("Please wage need");
                        int wage;
                        string answerWage;
                        answerWage = Console.ReadLine();
                        int.TryParse(answerWage, out wage);
                        modelCreation.GetEmployeeByWage(wage);
                        break;
                    default:
                        Console.WriteLine("I don't understand you, Newt");
                        break;
                }
            }
        }

        private int Answer()
        {
            string answer;
            int choice;

            do
            {
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out choice));

            return choice;

        }
    }
}
