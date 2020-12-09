using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class WorkerX : SaleWorker
    {
        public WorkerX(string name, double wage) : base(name, wage)
        {
            Position = Position.SaleWorkerX;
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
