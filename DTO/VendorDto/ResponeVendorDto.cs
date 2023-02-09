namespace Asp.net_core.DTO.VendorDto
{
    public class ResponeVendorDto
    {
       public int Id {get; set;}

       public string? Name {get; set;} 

       public int Birthdate {get; set;}

       public IList<ReceiptOfVendorResponeDto>? Receipts {get; set;}
    }
}