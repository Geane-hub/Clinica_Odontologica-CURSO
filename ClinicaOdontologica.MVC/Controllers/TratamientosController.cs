using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class TratamientoController : Controller
{
    // GET: Tratamiento
    public ActionResult Index()
    {
        var tratamientos = CRUD<Tratamiento>.GetAll();
        return View(tratamientos);
    }

    // GET: Tratamiento/Details/5
    public IActionResult Details(int id_tratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(id_tratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // GET: Tratamiento/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Tratamiento/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Create(tratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }
    }

    // GET: Tratamiento/Edit/5
    public ActionResult Edit(int id_tratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(id_tratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: Tratamiento/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_tratamiento, Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Update(id_tratamiento, tratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }
    }

    // GET: Tratamiento/Delete/5
    public ActionResult Delete(int id_tratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(id_tratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: Tratamiento/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_tratamiento, Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Delete(id_tratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }
    }
}