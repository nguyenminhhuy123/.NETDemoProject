namespace Asp.net_core.DTO.UserDto
{
    public class ResponeUserDto
    {
        public int Id {get; set;}
        
        public string? Name {get; set;}

        public string? UserName {get; set;}

        public string? Password {get; set;}

        public string? Role {get; set;}

        public ICollection<ReceiptOfUserResponeDto>? Receipts {get; set;} 
    }
}