using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_core.DTO.ReceiptsDto
{
    public class UpdateReceiptDto
    {
        public int IdVendor {get; set;}

        public int IdOwner {get; set;}

        public int IdCar {get; set;}
    }
}