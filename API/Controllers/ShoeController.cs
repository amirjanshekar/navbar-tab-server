using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.entities;
using API.data;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoeController: ControllerBase
    {
        private readonly DataContext _context;

        public ShoeController(DataContext context){
            _context = context;
        }
        [HttpPost(Name = "AddingShoe")]
        public async Task<ActionResult<Shoe>> AddShoe(AddRequestDTO addRequestDTO){
           Shoe shoe =
                new Shoe {
                    Title = addRequestDTO.Title,
                    Description = addRequestDTO.Description,
                    Image = addRequestDTO.Image,
                    Price = addRequestDTO.Price,
                    Category = addRequestDTO.Category,
                };
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }


        [HttpGet(Name = "GettingShoes")]
        public ActionResult<List<IQueryable<Shoe>>> GetShoes(){
            var filteredShoes = new List<IQueryable<Shoe>>{};
            filteredShoes.Add(_context.Shoes.Where<Shoe>(e => true));
            filteredShoes.Add(_context.Shoes.Where<Shoe>(e => e.Category == ShoeCategory.Sport));
            filteredShoes.Add(_context.Shoes.Where<Shoe>(e => e.Category == ShoeCategory.Party));
            filteredShoes.Add(_context.Shoes.Where<Shoe>(e => e.Category == ShoeCategory.Comf));
            return filteredShoes;
        }

        [HttpGet("{category}", Name = "GettingShoesByCategory")]
         public IQueryable<Shoe> GetShoesByCategory( ShoeCategory category){
            if (category == 0)
            {
                return _context.Shoes.Where<Shoe>(e => true);
            }
            else{
                return _context.Shoes.Where<Shoe>(e => e.Category == category);
            }
        }
    }
}