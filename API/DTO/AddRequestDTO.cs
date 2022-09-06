using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.entities;

namespace API.DTO
{
    public class AddRequestDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public ShoeCategory Category { get; set; }
        
    }
}