using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class HistorialMedicoController : Controller
{
    // GET: HistorialMedico
    public ActionResult Index()
    {
        var historialesMedicos = CRUD<HistorialMedico>.GetAll();
        return View(historialesMedicos);
    }

    // GET: HistorialMedico/Details/5
    public IActionResult Details(int id_historialmedico)
    {
        var historialMedico = CRUD<HistorialMedico>.GetById(id_historialmedico);
        if (historialMedico == null)
        {
            return NotFound();
        }
        return View(historialMedico);
    }

    // GET: HistorialMedico/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: HistorialMedico/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(HistorialMedico historialMedico)
    {
        try
        {
            CRUD<HistorialMedico>.Create(historialMedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialMedico);
        }
    }

    // GET: HistorialMedico/Edit/5
    public ActionResult Edit(int id_historialmedico)
    {
        var historialMedico = CRUD<HistorialMedico>.GetById(id_historialmedico);
        if (historialMedico == null)
        {
            return NotFound();
        }
        return View(historialMedico);
    }

    // POST: HistorialMedico/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_historialmedico, HistorialMedico historialMedico)
    {
        try
        {
            CRUD<HistorialMedico>.Update(id_historialmedico, historialMedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialMedico);
        }
    }

    // GET: HistorialMedico/Delete/5
    public ActionResult Delete(int id_historialmedico)
    {
        var historialMedico = CRUD<HistorialMedico>.GetById(id_historialmedico);
        if (historialMedico == null)
        {
            return NotFound();
        }
        return View(historialMedico);
    }

    // POST: HistorialMedico/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_historialmedico, HistorialMedico historialMedico)
    {
        try
        {
            CRUD<HistorialMedico>.Delete(id_historialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialMedico);
        }
    }
}