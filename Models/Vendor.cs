using System.ComponentModel.DataAnnotations;

namespace Asp.net_core.Models
{
    public class Vendor
    {
        public int Id {get; set;}

        [StringLength(30)]
        public string? Name {get; set;}

        public int Bithdate {get; set;}

        public virtual ICollection<Receipt>? Receipts { get; set; }

    }
}