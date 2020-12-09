using CompanyStructLib.Implementations;
using CompanyStructLib.Models;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CompanyStructLib.Tests
{
    public class DirectHierarchyStrategyTest
    {
        [Fact]
        public void GetHierarchy_Employyes_OrderedListByPosition()
        {
            var strategy = new DirectHierarchyStrategy();
            var employees = new List<Employee>
            {
                new WorkerA("WorkerA", 5000),
                new Director("Director", 20000),
                new WorkerY("WorkerY", 5500),
                new DeliveryManager("DeliveryManager", 10400)
            };

            var actual = strategy.GetHierarchy(employees);
            actual.Should().BeInAscendingOrder(emp => emp.Position);
        }
    }
}
