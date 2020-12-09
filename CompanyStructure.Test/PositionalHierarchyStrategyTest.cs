using CompanyStructLib.Implementations;
using CompanyStructLib.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CompanyStructLib.Tests
{
    public class PositionalHierarchyStrategyTest
    {
        [Fact]
        public void GetHierarchy_Employyes_OrderedListByPosition()
        {
            var strategy = new PositionalHierarchyStrategy();

            var d = new Director("Director", 20000);
            var wy = new WorkerY("WorkerY", 5500);
            var sm = new SaleManager("SaleManager", 10400);
            var dm = new DeliveryManager("DeliveryManager", 10400);


            d.AddSubordinate(sm);
            d.AddSubordinate(dm);
            sm.AddSubordinate(wy);

            var employees = new List<Employee> { d, wy, sm };

            var actual = strategy.GetHierarchy(employees).ToList();
            actual[0].Position.Should().Be(Position.Director);
            actual[1].Position.Should().Be(Position.SaleManager);
            actual[2].Position.Should().Be(Position.SaleWorkerY);
            actual[3].Position.Should().Be(Position.DeliveryManager);
        }
    }
}
