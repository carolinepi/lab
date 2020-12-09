using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using CompanyStructLib.Tests.FakeImplementations;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CompanyStructLib.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void Initializing_NotNull()
        {
            var company = new Company();
            company.Should().NotBeNull();
        }

        [Fact]
        public void AddEmployee_Null_ThrowsArgNullException()
        {
            var company = new Company();
            Action act = () => company.AddEmployee(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddEmployee_SameInstanceTwice_ThrowsException()
        {
            var company = new Company();
            var emp = new WorkerA("John", 4000);
            company.AddEmployee(emp);
            Action act = () => company.AddEmployee(emp);
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void AddEmployees_ListWithNull_ThrowsExceptionWithInnerNull()
        {
            var company = new Company();
            var employees = new List<Employee>
            {
                new WorkerA("John", 4000),
                null,
                new WorkerA("John", 6000)
            };

            Action act = () => company.AddEmployees(employees);

            act.Should().Throw<Exception>()
                        .WithInnerException<ArgumentNullException>();
        }

        [Fact]
        public void AddEmployees_ListWithNull_ThrowsExceptionWithInnerException()
        {
            var company = new Company();
            var employee = new WorkerA("Joni", 3000);
            var employees = new List<Employee>
            {
                employee,
                employee
            };

            Action act = () => company.AddEmployees(employees);

            act.Should().Throw<Exception>()
                        .WithInnerException<Exception>();
        }

        [Fact]
        public void SetHierarchyStrategy_Null_ThrowsArgNullException()
        {
            var company = new Company();
            Action act = () => company.SetHierarchyStrategy(null);
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void GetStructure_StrategyIsNotSet_ThrowsNullRefException()
        {
            var company = new Company();
            Action act = () => company.GetStructure();
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void GetStructure_FakeStrategyNullEmployees_ReturnsEmptyList()
        {
            IEnumerable<Employee> employees = new List<Employee>();
            var company = new Company();
            var mock = new Mock<IHierarchyStrategy>();
            mock.Setup(_ => _.GetHierarchy(employees)).Returns(employees);

            company.SetHierarchyStrategy(mock.Object);
            var res = company.GetStructure();
            res.Should().BeEmpty();
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(-0.0001)]
        public void GetByWage_IncorectParameter_ThrowsArgException(double wage)
        {
            var company = new Company();
            var emp = new WorkerA("John", 4000);
            company.AddEmployee(emp);
            Action act = () => company.GetByWage(wage);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GetByWage_LessThanMinimumWage_ReturnAllEmps()
        {
            var company = new Company();
            var expected = new List<Employee>
            {
                new WorkerA("John", 4000),
                new WorkerA("John", 5000),
                new WorkerA("John", 6000)
            };
            company.AddEmployees(expected);

            var actual = company.GetByWage(1000);

            actual.Should().NotBeEmpty()
                .And.HaveCount(expected.Count)
                .And.BeEquivalentTo(expected);
        }

        [Fact]
        public void GetByWage_BitGreaterThanMinimum_AllExceptOne()
        {
            var company = new Company();
            var employees = new List<Employee>
            {
                new WorkerA("John", 4000),
                new WorkerA("John", 5000),
                new WorkerA("John", 6000)
            };
            company.AddEmployees(employees);
            var expectedCount = 2;

            var actual = company.GetByWage(4200);

            actual.Should().NotBeEmpty()
                .And.HaveCount(expectedCount)
                .And.NotContain(emp => emp.Wage < 4200);
        }

        [Fact]
        public void GetHighestWage_NoEmployees_Zero()
        {
            var company = new Company();

            var actual = company.GetHighestWage();

            actual.Should().Be(0);
        }

        [Fact]
        public void GetHighestWage_ReturnsRighValue()
        {
            var company = new Company();
            var expected = 6000;
            var employees = new List<Employee>
            {
                new WorkerA("John", 4000),
                new WorkerA("John", 5000),
                new WorkerA("John", expected)
            };
            company.AddEmployees(employees);
            var actual = company.GetHighestWage();

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetByPosition_NoEmployees_EmptyList()
        {
            var company = new Company();
            var actual = company.GetByPosition(Position.DeliveryManager);
            actual.Should().HaveCount(0);
        }

        [Fact]
        public void GetByPosition_DeliveryManager_TwoElements()
        {
            var company = new Company();
            var employees = new List<Employee>
            {
                new DeliveryManager("John", 4000),
                new WorkerA("John", 5000),
                new DeliveryManager("John", 20000)
            };
            company.AddEmployees(employees);

            var actual = company.GetByPosition(Position.DeliveryManager);

            actual.Should().HaveCount(2)
                .And.Contain(emp => emp.Position == Position.DeliveryManager);
        }
    }
}
