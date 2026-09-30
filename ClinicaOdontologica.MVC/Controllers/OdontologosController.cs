using Clinica_odontologia.Models01;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class OdontologoController : Controller
{
    // GET: Odontologo
    public ActionResult Index()
    {
        var odontologos = CRUD<Odontologo>.GetAll();

        var citas = CRUD<Citas>.GetAll();
        var especialidades = CRUD<Especialidad>.GetAll();

        foreach (var odontologo in odontologos)
        {
            odontologo.Citas = citas
                .Where(c => c.IdOdontologo == odontologo.IdOdontologo)
                .ToList();

            odontologo.especialidad = especialidades
                .FirstOrDefault(e => e.IdEspecialidad == odontologo.IdEspecialidad);
        }

        return View(odontologos);
    }

    // GET: Odontologo/Details/5
    public IActionResult Details(int id)
    {
        var odontologo = CRUD<Odontologo>.GetById(id);

        if (odontologo == null)
        {
            return NotFound();
        }

        var citas = CRUD<Citas>.GetAll();
        var especialidades = CRUD<Especialidad>.GetAll();

        odontologo.Citas = citas
            .Where(c => c.IdOdontologo == odontologo.IdOdontologo)
            .ToList();

        odontologo.especialidad = especialidades
            .FirstOrDefault(e => e.IdEspecialidad == odontologo.IdEspecialidad);

        return View(odontologo);
    }

    // GET: Odontologo/Create
    public ActionResult Create()
    {
        var especialidades = CRUD<Especialidad>.GetAll();

        ViewBag.IdEspecialidad = new SelectList(
            especialidades,
            "IdEspecialidad",
            "NombreEspecialidad"
        );

        return View();
    }

    // POST: Odontologo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Create(odontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }

    // GET: Odontologo/Edit/5
    public ActionResult Edit(int id)
    {
        CRUD<Odontologo>.Endpoint =
            "https://localhost:7263/api/Odontologos";

        var odontologo = CRUD<Odontologo>.GetById(id);

        if (odontologo == null)
        {
            return NotFound();
        }

        var especialidades = CRUD<Especialidad>.GetAll();

        ViewBag.IdEspecialidad = new SelectList(
            especialidades,
            "IdEspecialidad",
            "NombreEspecialidad",
            odontologo.IdEspecialidad
        );

        return View(odontologo);
    }

    // POST: Odontologo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Odontologo odontologo)
    {
        CRUD<Odontologo>.Endpoint =
            "https://localhost:7263/api/Odontologos";

        try
        {
            CRUD<Odontologo>.Update(id, odontologo);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);

            var especialidades = CRUD<Especialidad>.GetAll();

            ViewBag.IdEspecialidad = new SelectList(
                especialidades,
                "IdEspecialidad",
                "NombreEspecialidad",
                odontologo.IdEspecialidad
            );

            return View(odontologo);
        }
    }

    // GET: Odontologo/Delete/5
    public ActionResult Delete(int id)
    {
        CRUD<Odontologo>.Endpoint =
            "https://localhost:7263/api/Odontologos";

        var odontologo = CRUD<Odontologo>.GetById(id);

        if (odontologo == null)
        {
            return NotFound();
        }

        return View(odontologo);
    }

    // POST: Odontologo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Odontologo odontologo)
    {
        CRUD<Odontologo>.Endpoint =
            "https://localhost:7263/api/Odontologos";

        try
        {
            CRUD<Odontologo>.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }
}