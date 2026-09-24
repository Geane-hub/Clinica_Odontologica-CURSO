using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class DetallescitasController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public DetallescitasController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Detallescita
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Detallescita>>> GetDetallescita()
    {
        return await _context.Detallescitas.ToListAsync();
    }

    // GET: api/Detallescita/5
    [HttpGet("{iddetallecita}")]
    public async Task<ActionResult<Detallescita>> GetDetallescita(int iddetallecita)
    {
        var detallescita = await _context.Detallescitas.FindAsync(iddetallecita);

        if (detallescita == null)
        {
            return NotFound();
        }

        return detallescita;
    }

    // PUT: api/Detallescita/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{iddetallecita}")]
    public async Task<IActionResult> PutDetallescita(int? iddetallecita, Detallescita detallescita)
    {
        if (iddetallecita != detallescita.IdDetallecita)
        {
            return BadRequest();
        }

        _context.Entry(detallescita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetallescitaExists(iddetallecita))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Detallescita
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Detallescita>> PostDetallescita(Detallescita detallescita)
    {
        _context.Detallescitas.Add(detallescita);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDetallescita", new { iddetallecita = detallescita.IdDetallecita }, detallescita);
    }

    // DELETE: api/Detallescita/5
    [HttpDelete("{iddetallecita}")]
    public async Task<IActionResult> DeleteDetallescita(int? iddetallecita)
    {
        var detallescita = await _context.Detallescitas.FindAsync(iddetallecita);
        if (detallescita == null)
        {
            return NotFound();
        }

        _context.Detallescitas.Remove(detallescita);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetallescitaExists(int? iddetallecita)
    {
        return _context.Detallescitas.Any(e => e.IdDetallecita == iddetallecita);
    }
}
