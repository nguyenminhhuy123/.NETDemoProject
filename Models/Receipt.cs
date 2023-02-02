namespace Asp.net_core.Models
{
    public class Receipt
    {

        public Receipt()
        {
            Vendor = new Vendor();
            Owner = new Owner();
            Car = new Car();
        }
        public int Id {get; set;}

        public int IdCar {get; set;}

        public virtual Vendor Vendor {get; set;}

        public virtual Owner Owner {get; set;}

        public virtual Car Car {get; set;}
        
    }
}