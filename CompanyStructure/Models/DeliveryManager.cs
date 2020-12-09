using System.Collections.Generic;
using System.Linq;
using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class DeliveryManager : Manager
    {
        private readonly IList<DeliveryWorker> _workers;

        public DeliveryManager(string name, double wage) : base(name, wage)
        {
            Position = Position.DeliveryManager;
            _workers = new List<DeliveryWorker>();
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this, _workers);
        }

        public void AddSubordinate(DeliveryWorker worker)
        {
            var subordinate = _workers.FirstOrDefault(wrkr => wrkr.Id == worker.Id);

            if (subordinate is null)
                _workers.Add(worker);
        }

        public override List<Employee> GetSubordinates()
        {
            var res = new List<Employee>();
            res.Add(this);
            foreach (var worker in _workers)
            {
                res.AddRange(worker.GetSubordinates());
            }
            return res;
        }
    }
}
