namespace Asp.net_core.Models
{
    public class Receipt
    {

        public Receipt()
        {
            Vendor = new Vendor();
            User = new User();
            Car = new Car();
        }
        public int Id {get; set;}

        public int IdCar {get; set;}

        public int IdVendor {get; set;}

        public int IdUser {get; set;}

        public virtual Vendor Vendor {get; set;}

        public virtual User User {get; set;}

        public virtual Car Car {get; set;}
        
    }
}