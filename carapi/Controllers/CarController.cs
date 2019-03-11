using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carapi.Models;

namespace carapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;

            if (_context.CarItems.Count() == 0)
            {
               
                _context.CarItems.Add(new CarItems { Id = 1 , CarName ="Mercedes Benz C" , Color="Blue", Company = "mercedes", Engine = "v8"});
                _context.CarItems.Add(new CarItems { Id = 2 , CarName ="Audi A3" , Color="Black", Company = "Audi", Engine = "t8"});
                _context.SaveChanges();
            }
            
        }
        // GET: api/Car
        [HttpGet]
            public async Task<ActionResult<IEnumerable<CarItems>>> GetCarItems()
            {
                return await _context.CarItems.ToListAsync();
            }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarItems>> GetCarItem(long id)
        {
            var carItem = await _context.CarItems.FindAsync(id);

            if (carItem == null)
            {
            return NotFound();
            }

            return carItem;
        }

        [HttpPost]
        public async Task<ActionResult<CarItems>> PostCarItem(CarItems item)
        {
            _context.CarItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarItem), new { id = item.Id }, item);
        }

    }

}