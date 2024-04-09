using JornadaMilhasApp.Data;
using JornadaMilhasApp.DTO;
using JornadaMilhasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhasApp.Controllers
{
    [Route("/destinos")]
    [ApiController]
    public class DestinyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DestinyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("O parâmetro de pesquisa não pode ser vazio.");
            }


            var destinies = await _context.Destinies
                .Where(d => d.Name.Contains(name) || d.Photo.Contains(name) || d.Price.ToString().Contains(name))
                .ToListAsync();
            if (!destinies.Any())
            {
                return BadRequest("Nenhum destino foi encontrado.");
            }

            return Ok(destinies);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var destinies = await _context.Destinies.ToListAsync();
            return Ok(destinies);
        }

        [HttpGet("{id}", Name = "GetDestiny")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var destinies = await _context.Destinies.FirstOrDefaultAsync(x => x.Id == id);
            if (destinies == null)
            {
                return BadRequest("Nenhum destino foi encontrado.");
            }

            var destinyDto = new DestinyDto()
            {
                Id = destinies.Id,
                Name = destinies.Name,
                Photo = destinies.Photo,
                PhotoTwo = destinies.PhotoTwo,
                Meta = destinies.Meta,
                Description = destinies.Description
            };

            return Ok(destinyDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Destiny destiny)
        {
            if (destiny == null)
            {
                return BadRequest("Destiny cannot be null.");
            }

            if (string.IsNullOrEmpty(destiny.Description))
            {
                var pronpt = $"Escreva algo sobre um lugar com no maximo 100 caracteres";

                destiny.Description = "Alguma descrição gerada pelo chatGPT que não deu certo kkkkkk";
            }

            _context.Destinies.Add(destiny);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = destiny.Id }, destiny);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Destiny destiny)
        {
            var destinies = await _context.Destinies.FirstOrDefaultAsync(x => x.Id == id);
            if (destinies == null)
            {
                return NotFound();
            }

            destinies.Name = destiny.Name;
            destinies.Photo = destiny.Photo;
            destinies.Price = destiny.Price;
            destinies.PhotoTwo = destiny.PhotoTwo;
            destinies.Description = destiny.Description;
            destinies.Meta = destiny.Meta;

            _context.Destinies.Update(destinies);
            await _context.SaveChangesAsync();

            return Ok(destinies);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var destinies = await _context.Destinies.FirstOrDefaultAsync(x => x.Id == id);

            if (destinies == null)
            {
                return NotFound();
            }

            _context.Destinies.Remove(destinies);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}