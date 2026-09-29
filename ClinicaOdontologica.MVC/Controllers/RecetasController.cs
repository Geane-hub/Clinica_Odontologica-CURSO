using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class RecetaController : Controller
{
    // GET: Receta
    public ActionResult Index()
    {
        var recetas = CRUD<Receta>.GetAll();
        return View(recetas);
    }

    // GET: Receta/Details/5
    public IActionResult Details(int id_receta)
    {
        var receta = CRUD<Receta>.GetById(id_receta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // GET: Receta/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Receta/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Receta receta)
    {
        try
        {
            CRUD<Receta>.Create(receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: Receta/Edit/5
    public ActionResult Edit(int id_receta)
    {
        var receta = CRUD<Receta>.GetById(id_receta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: Receta/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_receta, Receta receta)
    {
        try
        {
            CRUD<Receta>.Update(id_receta, receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: Receta/Delete/5
    public ActionResult Delete(int id_receta)
    {
        var receta = CRUD<Receta>.GetById(id_receta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: Receta/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_receta, Receta receta)
    {
        try
        {
            CRUD<Receta>.Delete(id_receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }
}