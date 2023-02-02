using Asp.net_core.Models;

namespace Asp.net_core.DTO.Owner
{
    public class ResponeOwnerDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}

        public List<Receipt>? Receipts {get; set;} 
    }
}