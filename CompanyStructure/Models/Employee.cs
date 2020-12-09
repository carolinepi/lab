using CompanyStructLib.Interfaces;
using System;
using System.Collections.Generic;

namespace CompanyStructLib.Models
{
    public enum Position
    {
        Director,
        DeliveryManager,
        SaleManager,
        DeliveryWorkerA,
        DeliveryWorkerB,
        SaleWorkerX,
        SaleWorkerY,
    }

    public abstract class Employee
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public double Wage { get; private set; }

        public Position Position { get; set; }

        public Employee(string name, double wage)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Parameter 'name' cannot be null or blank.");

            if (wage < 0)
                throw new ArgumentException($"Parameter 'wage' cannot be less than zero.\nYour input: {wage}");

            Id = Guid.NewGuid();
            Name = name;
            Wage = wage;
        }

        public virtual List<Employee> GetSubordinates()
        {
            return new List<Employee> { this };
        }

        public abstract void AcceptVisitor(IVisitor visitor);
    }
}
