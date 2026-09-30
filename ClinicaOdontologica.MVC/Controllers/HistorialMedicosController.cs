using Clinica_odontologia.Models01;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class HistorialMedicoController : Controller
{
    // GET: HistorialMedico
    public ActionResult Index()
    {
        var historialesMedicos = CRUD<HistorialMedico>.GetAll();
        var pacientes = CRUD<Paciente>.GetAll();

        foreach (var historialMedico in historialesMedicos)
        {
            historialMedico.paciente = pacientes
                .FirstOrDefault(p => p.IdPaciente == historialMedico.IdPaciente);
        }

        return View(historialesMedicos);
    }

    // GET: HistorialMedico/Details/5
    public IActionResult Details(int id)
    {
        var historialMedico = CRUD<HistorialMedico>.GetById(id);
        if (historialMedico == null)
        {
            return NotFound();
        }
        return View(historialMedico);
    }

    // GET: HistorialMedico/Create
    public ActionResult Create()
    {
        var pacientes = CRUD<Paciente>.GetAll();

        ViewBag.IdPaciente = new SelectList(
            pacientes,
            "IdPaciente",
            "Nombres"
        );

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
    public ActionResult Edit(int id)
    {
        var historialMedico = CRUD<HistorialMedico>.GetById(id);

        if (historialMedico == null)
        {
            return NotFound();
        }

        var pacientes = CRUD<Paciente>.GetAll();

        ViewBag.IdPaciente = new SelectList(
            pacientes,
            "IdPaciente",
            "Nombres",
            historialMedico.IdPaciente
        );

        return View(historialMedico);
    }

    // POST: HistorialMedico/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, HistorialMedico historialMedico)
    {
        try
        {
            historialMedico.idHistorialMedico = id;

            CRUD<HistorialMedico>.Update(id, historialMedico);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);

            var pacientes = CRUD<Paciente>.GetAll();

            ViewBag.IdPaciente = new SelectList(
                pacientes,
                "IdPaciente",
                "Nombres",
                historialMedico.IdPaciente
            );

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
    public ActionResult Delete(int id, HistorialMedico historialMedico)
    {
        try
        {
            CRUD<HistorialMedico>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialMedico);
        }
    }
}