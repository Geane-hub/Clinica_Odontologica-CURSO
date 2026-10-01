
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica_odontologia.Models01;

public class UsuariosController : Controller
{
    private readonly Clinica_OdontologicaAPIContext _context;

    public UsuariosController(Clinica_OdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: USUARIOCSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Usuario.ToListAsync());
    }

    // GET: USUARIOCSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariocs = await _context.Usuariocs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (usuariocs == null)
        {
            return NotFound();
        }

        return View(usuariocs);
    }

    // GET: USUARIOCSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: USUARIOCSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,nombre,apellido,nombreUsuario,contrasenia")] Usuariocs usuariocs)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuariocs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(usuariocs);
    }

    // GET: USUARIOCSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariocs = await _context.Usuariocs.FindAsync(id);
        if (usuariocs == null)
        {
            return NotFound();
        }
        return View(usuariocs);
    }

    // POST: USUARIOCSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,nombre,apellido,nombreUsuario,contrasenia")] Usuariocs usuariocs)
    {
        if (id != usuariocs.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(usuariocs);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariocsExists(usuariocs.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(usuariocs);
    }

    // GET: USUARIOCSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariocs = await _context.Usuariocs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (usuariocs == null)
        {
            return NotFound();
        }

        return View(usuariocs);
    }

    // POST: USUARIOCSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var usuariocs = await _context.Usuariocs.FindAsync(id);
        if (usuariocs != null)
        {
            _context.Usuariocs.Remove(usuariocs);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UsuariocsExists(int? id)
    {
        return _context.Usuariocs.Any(e => e.Id == id);
    }
}
