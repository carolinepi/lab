using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class WorkerA : DeliveryWorker
    {
        public WorkerA(string name, double wage) : base(name, wage)
        {
            Position = Position.DeliveryWorkerA;
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
