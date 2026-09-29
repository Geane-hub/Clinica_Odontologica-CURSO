using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class OdontologoController : Controller
{
    // GET: Odontologo
    public ActionResult Index()
    {
        var odontologos = CRUD<Odontologo>.GetAll();
        return View(odontologos);
    }

    // GET: Odontologo/Details/5
    public IActionResult Details(int id_odontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(id_odontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // GET: Odontologo/Create
    public ActionResult Create()
    {
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
    public ActionResult Edit(int id_odontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(id_odontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: Odontologo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_odontologo, Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Update(id_odontologo, odontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }

    // GET: Odontologo/Delete/5
    public ActionResult Delete(int id_odontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(id_odontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: Odontologo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_odontologo, Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Delete(id_odontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }
}