using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.entities
{
    public class Shoe
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public ShoeCategory Category { get; set; }
    }
}