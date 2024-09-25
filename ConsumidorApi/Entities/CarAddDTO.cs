using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumidorApi.Entities
{
    internal class CarAddDTO
    { 
        public string Name { get; set; }
        public BetweenDTO Staff { get; set; }
    }

    public class BetweenDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}

