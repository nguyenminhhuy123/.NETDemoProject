using System.ComponentModel.DataAnnotations;

namespace Asp.net_core.Models
{
    public class Owner
    {
        public int Id {get; set;}

        [StringLength(30)]
        public string? Name {get; set;}

        public virtual ICollection<Receipt>? Receipts { get; set; }
    }
}