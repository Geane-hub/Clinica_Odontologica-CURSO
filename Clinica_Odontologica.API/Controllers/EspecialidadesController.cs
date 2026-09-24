using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class EspecialidadesController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public EspecialidadesController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Especialidad
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidad()
    {
        return await _context.Especialidads.ToListAsync();
    }

    // GET: api/Especialidad/5
    [HttpGet("{idespecialidad}")]
    public async Task<ActionResult<Especialidad>> GetEspecialidad(int idespecialidad)
    {
        var especialidad = await _context.Especialidads.FindAsync(idespecialidad);

        if (especialidad == null)
        {
            return NotFound();
        }

        return especialidad;
    }

    // PUT: api/Especialidad/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idespecialidad}")]
    public async Task<IActionResult> PutEspecialidad(int? idespecialidad, Especialidad especialidad)
    {
        if (idespecialidad != especialidad.IdEspecialidad)
        {
            return BadRequest();
        }

        _context.Entry(especialidad).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EspecialidadExists(idespecialidad))
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

    // POST: api/Especialidad
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad especialidad)
    {
        _context.Especialidads.Add(especialidad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEspecialidad", new { idespecialidad = especialidad.IdEspecialidad }, especialidad);
    }

    // DELETE: api/Especialidad/5
    [HttpDelete("{idespecialidad}")]
    public async Task<IActionResult> DeleteEspecialidad(int? idespecialidad)
    {
        var especialidad = await _context.Especialidads.FindAsync(idespecialidad);
        if (especialidad == null)
        {
            return NotFound();
        }

        _context.Especialidads.Remove(especialidad);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EspecialidadExists(int? idespecialidad)
    {
        return _context.Especialidads.Any(e => e.IdEspecialidad == idespecialidad);
    }
}
