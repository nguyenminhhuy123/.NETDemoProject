using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_core.Models
{
    public class Car
    {
        public int Id {get; set;}
        public int Name {get; set;}

        public virtual Owner Owners { get; set; }
    }
}