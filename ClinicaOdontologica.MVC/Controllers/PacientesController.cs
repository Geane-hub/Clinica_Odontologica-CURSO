using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class PacienteController : Controller
{
    // GET: Paciente
    public ActionResult Index()
    {
        var pacientes = CRUD<Paciente>.GetAll();
        return View(pacientes);
    }

    // GET: Paciente/Details/5
    public IActionResult Details(int id_paciente)
    {
        var paciente = CRUD<Paciente>.GetById(id_paciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // GET: Paciente/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Paciente/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Create(paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: Paciente/Edit/5
    public ActionResult Edit(int id_paciente)
    {
        var paciente = CRUD<Paciente>.GetById(id_paciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: Paciente/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_paciente, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Update(id_paciente, paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: Paciente/Delete/5
    public ActionResult Delete(int id_paciente)
    {
        var paciente = CRUD<Paciente>.GetById(id_paciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: Paciente/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_paciente, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Delete(id_paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }
}