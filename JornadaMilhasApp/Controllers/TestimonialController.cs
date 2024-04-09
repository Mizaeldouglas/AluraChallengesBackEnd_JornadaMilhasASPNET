using JornadaMilhasApp.Data;
using JornadaMilhasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhasApp.Controllers;

[Route("depoimentos")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly AppDbContext _context;

    public TestimonialController(AppDbContext context)
    {
        _context = context;
    }
    
    //Get Last 3 Testimonial
    [HttpGet("/depoimentos-home")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLastComments()
    {
        var testimonials = await _context.Testimonials.OrderByDescending(t => t.Id).Take(3).ToListAsync();
        return Ok(testimonials);
    }
    
    
    // GET: api/Testimonial
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get() => Ok(await _context.Testimonials.ToListAsync());

    // GET: api/Testimonial/5
    [HttpGet("{id}", Name = "GetTestimonial")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var testimonial = await _context.Testimonials.FirstOrDefaultAsync(x => x.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }

        return Ok(testimonial);
    }

    // POST: api/Testimonial
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Testimonial testimonial)
    {
        _context.Testimonials.Add(testimonial);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", new {id = testimonial.Id}, testimonial);
    }

    // PUT: api/Testimonial/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Testimonial testimonial)
    {
        var existingTestimonial = await _context.Testimonials.FirstOrDefaultAsync(x => x.Id == id);

        if (existingTestimonial == null)
        {
            return NotFound();
        }
        
        existingTestimonial.Name = testimonial.Name;
        existingTestimonial.Comment = testimonial.Comment;
        existingTestimonial.Photo = testimonial.Photo;

        _context.Testimonials.Update(existingTestimonial);
        await _context.SaveChangesAsync();
        
        return Ok(existingTestimonial);
    }

    // DELETE: api/Testimonial/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var existingTestimonial = await _context.Testimonials.FirstOrDefaultAsync(x => x.Id == id);
        if (existingTestimonial == null)
        {
            return NotFound();
        }

        _context.Remove(existingTestimonial);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
    
    
}