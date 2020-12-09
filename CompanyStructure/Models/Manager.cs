namespace CompanyStructLib.Models
{
    public abstract class Manager : Employee
    {
        public Manager(string name, double wage) : base(name, wage)
        {
        }
    }
}
