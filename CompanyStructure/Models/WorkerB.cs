using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class WorkerB : DeliveryWorker
    {
        public WorkerB(string name, double wage) : base(name, wage)
        {
            Position = Position.DeliveryWorkerB;
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
