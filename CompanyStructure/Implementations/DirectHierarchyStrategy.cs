using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Implementations
{
    public class DirectHierarchyStrategy : IHierarchyStrategy
    {
        public IEnumerable<Employee> GetHierarchy(IEnumerable<Employee> employees)
        {
            return employees.OrderBy(employee => employee.Position);
        }
    }
}
