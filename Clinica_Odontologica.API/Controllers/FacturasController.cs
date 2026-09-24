using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

[Route("api/[controller]")]
[ApiController]
public class FacturasController : ControllerBase
{
    private readonly Clinica_OdontologicaAPIContext _context;
    public FacturasController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Facturas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Facturas>>> GetFacturas()
    {
        return await _context.Facturas.ToListAsync();
    }

    // GET: api/Facturas/5
    [HttpGet("{idfactura}")]
    public async Task<ActionResult<Facturas>> GetFacturas(int idfactura)
    {
        var facturas = await _context.Facturas.FindAsync(idfactura);

        if (facturas == null)
        {
            return NotFound();
        }

        return facturas;
    }

    // PUT: api/Facturas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idfactura}")]
    public async Task<IActionResult> PutFacturas(int? idfactura, Facturas facturas)
    {
        if (idfactura != facturas.IdFactura)
        {
            return BadRequest();
        }

        _context.Entry(facturas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FacturasExists(idfactura))
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

    // POST: api/Facturas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Facturas>> PostFacturas(Facturas facturas)
    {
        _context.Facturas.Add(facturas);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFacturas", new { idfactura = facturas.IdFactura }, facturas);
    }

    // DELETE: api/Facturas/5
    [HttpDelete("{idfactura}")]
    public async Task<IActionResult> DeleteFacturas(int? idfactura)
    {
        var facturas = await _context.Facturas.FindAsync(idfactura);
        if (facturas == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(facturas);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FacturasExists(int? idfactura)
    {
        return _context.Facturas.Any(e => e.IdFactura == idfactura);
    }
}
