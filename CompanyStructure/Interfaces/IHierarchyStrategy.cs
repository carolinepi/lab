using CompanyStructLib.Models;
using System.Collections.Generic;

namespace CompanyStructLib.Interfaces
{
    public interface IHierarchyStrategy
    {
        IEnumerable<Employee> GetHierarchy(IEnumerable<Employee> employees);
    }
}
