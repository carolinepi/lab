using CompanyStructLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Models
{
    public class Company
    {
        private readonly HashSet<Employee> _employees;
        private IHierarchyStrategy _hierarchyStrategy;

        public Company()
        {
            _employees = new HashSet<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException("Value cannot be null");

            if (!_employees.Add(employee))
                throw new Exception("An employee is already added to this company");
        }

        public void AddEmployees(IEnumerable<Employee> employees)
        {
            try
            {
                foreach (var emp in employees)
                    AddEmployee(emp);
            }
            catch(Exception ex)
            {
                _employees.Clear();
                throw new Exception("There is incorect data in the list", ex);
            }
        }

        public void SetHierarchyStrategy(IHierarchyStrategy strategy)
        {
            if (strategy is null)
                throw new ArgumentNullException("Parameter cannot be null value.");

            _hierarchyStrategy = strategy;
        }

        public IEnumerable<Employee> GetByWage(double wage)
        {
            if (wage <= 0)
                throw new ArgumentException("Parameter 'wage' cannot be less or equal to zero");

            return _employees.Where(emp => emp.Wage >= wage);
        }

        public double GetHighestWage()
        {
            if (_employees.Count == 0)
                return 0;

            return _employees.Max(emp => emp.Wage);
        }

        public IEnumerable<Employee> GetByPosition(Position position)
        {
            return _employees.Where(emp => emp.Position == position);
        }

        public IEnumerable<Employee> GetStructure()
        {
            if (_hierarchyStrategy is null)
                throw new NullReferenceException("Field '_hierarchyStrategy' cannot be null");

            return _hierarchyStrategy.GetHierarchy(_employees);
        }
    }
}
