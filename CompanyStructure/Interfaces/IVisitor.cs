using CompanyStructLib.Models;
using System.Collections.Generic;

namespace CompanyStructLib.Interfaces
{
    public interface IVisitor
    {
        void Visit(Director director, IEnumerable<Employee> subordinates);
        void Visit(SaleManager saleManager, IEnumerable<Employee> subordinates);
        void Visit(DeliveryManager deliveryManager, IEnumerable<Employee> subordinates);
        void Visit(WorkerA workerA);
        void Visit(WorkerB workerB);
        void Visit(WorkerX workerX);
        void Visit(WorkerY workerY);
    }
}
