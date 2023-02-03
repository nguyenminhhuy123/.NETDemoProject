using Asp.net_core.DTO.ReceiptsDto;
using Asp.net_core.Models;

namespace Asp.net_core.DTO.OwnerDto
{
    public class ResponeOwnerDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}

        public ICollection<ResponeReceiptDto>? Receipts {get; set;} 
    }
}