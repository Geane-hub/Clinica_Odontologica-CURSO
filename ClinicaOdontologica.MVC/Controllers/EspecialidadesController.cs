using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class EspecialidadController : Controller
{
    // GET: Especialidad
    public ActionResult Index()
    {
        var especialidades = CRUD<Especialidad>.GetAll();
        return View(especialidades);
    }

    // GET: Especialidad/Details/5
    public IActionResult Details(int id_especialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(id_especialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // GET: Especialidad/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Especialidad/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Create(especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: Especialidad/Edit/5
    public ActionResult Edit(int id_especialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(id_especialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: Especialidad/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_especialidad, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Update(id_especialidad, especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: Especialidad/Delete/5
    public ActionResult Delete(int id_especialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(id_especialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: Especialidad/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_especialidad, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Delete(id_especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }
}