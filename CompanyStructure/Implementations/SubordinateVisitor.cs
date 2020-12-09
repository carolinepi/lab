using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Implementations
{
    public class SubordinateVisitor : IVisitor
    {
        private List<Employee> _subordinates = new List<Employee>();

        public List<Employee> Get() => _subordinates;
        
        public void Visit(Director director, IEnumerable<Employee> subordinates)
        {
            _subordinates = subordinates.ToList();
        }

        public void Visit(SaleManager saleManager, IEnumerable<Employee> subordinates)
        {
            _subordinates = subordinates.ToList();
        }

        public void Visit(DeliveryManager deliveryManager, IEnumerable<Employee> subordinates)
        {
            _subordinates = subordinates.ToList();
        }

        public void Visit(WorkerA workerA)
        {
            _subordinates.Clear();
        }

        public void Visit(WorkerB workerB)
        {
            _subordinates.Clear();
        }

        public void Visit(WorkerX workerX)
        {
            _subordinates.Clear();
        }

        public void Visit(WorkerY workerY)
        {
            _subordinates.Clear();
        }
    }
}
