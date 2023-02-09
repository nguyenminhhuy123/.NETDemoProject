using System.ComponentModel.DataAnnotations;

namespace Asp.net_core.Models
{
    public class User
    {
        public int Id {get; set;}

        [StringLength(30)]
        public string? Name {get; set;}

        [StringLength(30)]
        public string? UserName {get; set;}

        [StringLength(20)]
        public string? Role {get; set;}

        public string? Password {get; set;}

        public virtual ICollection<Receipt>? Receipts { get; set; }
    }
}