namespace Asp.net_core.DTO.CarDto
{
    public class ResponeCarDto
    {
        public int Id {get; set;}

        public string? Name {get; set;}

        public double Price {get; set;}

        public ReceiptOfCarResponeDto? Receipt {get; set;}
    }
}