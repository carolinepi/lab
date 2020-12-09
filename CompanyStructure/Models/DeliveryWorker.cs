namespace CompanyStructLib.Models
{
    public abstract class DeliveryWorker : Employee
    {
        public DeliveryWorker(string name, double wage) : base(name, wage)
        {
        }
    }
}
