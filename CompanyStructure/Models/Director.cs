using System.Collections.Generic;
using System.Linq;
using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class Director : Employee
    {
        private readonly IList<Manager> _managers;

        public Director(string name, double wage) : base(name, wage)
        {
            Position = Position.Director;
            _managers = new List<Manager>();
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this, _managers);
        }

        public void AddSubordinate(Manager manager)
        {
            var subordinate = _managers.FirstOrDefault(mng => mng.Id == manager.Id);

            if (subordinate is null)
                _managers.Add(manager);
        }

        public override List<Employee> GetSubordinates()
        {
            var res = new List<Employee>();
            res.Add(this);
            foreach(var mng in _managers)
            {
                res.AddRange(mng.GetSubordinates());
            }
            return res;
        }
    }
}
