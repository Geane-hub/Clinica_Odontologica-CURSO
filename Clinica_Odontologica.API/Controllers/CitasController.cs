using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class CitasController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public CitasController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Citas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Citas>>> GetCitas()
    {
        return await _context.Citas.ToListAsync();
    }

    // GET: api/Citas/5
    [HttpGet("{id_cita}")]
    public async Task<ActionResult<Citas>> GetCitas(int id_cita)
    {
        var citas = await _context.Citas.FindAsync(id_cita);

        if (citas == null)
        {
            return NotFound();
        }

        return citas;
    }

    // PUT: api/Citas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_cita}")]
    public async Task<IActionResult> PutCitas(int? id_cita, Citas citas)
    {
        if (id_cita != citas.Id_cita)
        {
            return BadRequest();
        }

        _context.Entry(citas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CitasExists(id_cita))
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

    // POST: api/Citas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Citas>> PostCitas(Citas citas)
    {
        _context.Citas.Add(citas);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCitas", new { id_cita = citas.Id_cita }, citas);
    }

    // DELETE: api/Citas/5
    [HttpDelete("{id_cita}")]
    public async Task<IActionResult> DeleteCitas(int? id_cita)
    {
        var citas = await _context.Citas.FindAsync(id_cita);
        if (citas == null)
        {
            return NotFound();
        }

        _context.Citas.Remove(citas);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CitasExists(int? id_cita)
    {
        return _context.Citas.Any(e => e.Id_cita == id_cita);
    }
}
