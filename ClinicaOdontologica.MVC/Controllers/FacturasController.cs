using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class FacturaController : Controller
{
    // GET: Factura
    public ActionResult Index()
    {
        var facturas = CRUD<Facturas>.GetAll();
        return View(facturas);
    }

    // GET: Factura/Details/5
    public IActionResult Details(int id)
    {
        var factura = CRUD<Facturas>.GetById(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // GET: Factura/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Factura/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Facturas factura)
    {
        try
        {
            CRUD<Facturas>.Create(factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: Factura/Edit/5
    public ActionResult Edit(int id)
    {
        var factura = CRUD<Facturas>.GetById(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: Factura/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Facturas factura)
    {
        try
        {
            CRUD<Facturas>.Update(id, factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: Factura/Delete/5
    public ActionResult Delete(int id)
    {
        var factura = CRUD<Facturas>.GetById(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: Factura/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Facturas factura)
    {
        try
        {
            CRUD<Facturas>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }
}