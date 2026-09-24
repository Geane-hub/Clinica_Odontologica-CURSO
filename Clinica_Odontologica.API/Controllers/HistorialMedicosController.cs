using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class HistorialMedicosController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public HistorialMedicosController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/HistorialMedico
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialMedico()
    {
        return await _context.HistorialMedicos.ToListAsync();
    }

    // GET: api/HistorialMedico/5
    [HttpGet("{idhistorialmedico}")]
    public async Task<ActionResult<HistorialMedico>> GetHistorialMedico(int idhistorialmedico)
    {
        var historialmedico = await _context.HistorialMedicos.FindAsync(idhistorialmedico);

        if (historialmedico == null)
        {
            return NotFound();
        }

        return historialmedico;
    }

    // PUT: api/HistorialMedico/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idhistorialmedico}")]
    public async Task<IActionResult> PutHistorialMedico(int? idhistorialmedico, HistorialMedico historialmedico)
    {
        if (idhistorialmedico != historialmedico.idHistorialMedico)
        {
            return BadRequest();
        }

        _context.Entry(historialmedico).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HistorialMedicoExists(idhistorialmedico))
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

    // POST: api/HistorialMedico
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<HistorialMedico>> PostHistorialMedico(HistorialMedico historialmedico)
    {
        _context.HistorialMedicos.Add(historialmedico);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHistorialMedico", new { idhistorialmedico = historialmedico.idHistorialMedico }, historialmedico);
    }

    // DELETE: api/HistorialMedico/5
    [HttpDelete("{idhistorialmedico}")]
    public async Task<IActionResult> DeleteHistorialMedico(int? idhistorialmedico)
    {
        var historialmedico = await _context.HistorialMedicos.FindAsync(idhistorialmedico);
        if (historialmedico == null)
        {
            return NotFound();
        }

        _context.HistorialMedicos.Remove(historialmedico);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HistorialMedicoExists(int? idhistorialmedico)
    {
        return _context.HistorialMedicos.Any(e => e.idHistorialMedico == idhistorialmedico);
    }
}
