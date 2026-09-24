using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class TratamientosController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public TratamientosController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Tratamiento
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamiento()
    {
        return await _context.Tratamientos.ToListAsync();
    }

    // GET: api/Tratamiento/5
    [HttpGet("{idtratamiento}")]
    public async Task<ActionResult<Tratamiento>> GetTratamiento(int idtratamiento)
    {
        var tratamiento = await _context.Tratamientos.FindAsync(idtratamiento);

        if (tratamiento == null)
        {
            return NotFound();
        }

        return tratamiento;
    }

    // PUT: api/Tratamiento/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idtratamiento}")]
    public async Task<IActionResult> PutTratamiento(int? idtratamiento, Tratamiento tratamiento)
    {
        if (idtratamiento != tratamiento.IdTratamiento)
        {
            return BadRequest();
        }

        _context.Entry(tratamiento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TratamientoExists(idtratamiento))
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

    // POST: api/Tratamiento
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento)
    {
        _context.Tratamientos.Add(tratamiento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTratamiento", new { idtratamiento = tratamiento.IdTratamiento }, tratamiento);
    }

    // DELETE: api/Tratamiento/5
    [HttpDelete("{idtratamiento}")]
    public async Task<IActionResult> DeleteTratamiento(int? idtratamiento)
    {
        var tratamiento = await _context.Tratamientos.FindAsync(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }

        _context.Tratamientos.Remove(tratamiento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TratamientoExists(int? idtratamiento)
    {
        return _context.Tratamientos.Any(e => e.IdTratamiento == idtratamiento);
    }
}
