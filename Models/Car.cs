using System.ComponentModel.DataAnnotations;

namespace Asp.net_core.Models
{
    public class Car
    {
        public int Id {get; set;}

        [StringLength(30)]
        public string? Name {get; set;}

        public double Price {get; set;}

        public virtual Receipt? receipt { get; set; }
    }
}