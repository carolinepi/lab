using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class WorkerY : SaleWorker
    {
        public WorkerY(string name, double wage) : base(name, wage)
        {
            Position = Position.SaleWorkerY;
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
