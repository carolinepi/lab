using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Implementations
{
    public class PositionalHierarchyStrategy : IHierarchyStrategy
    {
        public IEnumerable<Employee> GetHierarchy(IEnumerable<Employee> employees)
        {
            var highestEmployee = employees.OrderBy(emp => emp.Position).FirstOrDefault();

            if (highestEmployee is null)
                throw new Exception("It seems like there is no employees in this company");

            return highestEmployee.GetSubordinates();

        }
    }
}
