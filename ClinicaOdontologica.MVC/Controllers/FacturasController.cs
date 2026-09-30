using Clinica_odontologia.Models01;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class FacturasController : Controller
{
    // GET: Factura
    public ActionResult Index()
    {
        var facturas = CRUD<Facturas>.GetAll();
        var citas = CRUD<Citas>.GetAll();

        foreach (var factura in facturas)
        {
            factura.citas = citas
                .FirstOrDefault(c => c.Id_cita == factura.IdCita);
        }

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

        // Cargar los datos de la Cita asociada para mostrar la información del paciente
        if (factura.IdCita != null)
        {
            var citas = CRUD<Citas>.GetAll() ?? new List<Citas>();
            factura.citas = citas.FirstOrDefault(c => c.Id_cita == factura.IdCita);
        }

        return View(factura);
    }

    // GET: Factura/Create
    public ActionResult Create()
    {
        // 1. Asignar el endpoint del servicio para Citas (ajusta la URL según tu API)
        CRUD<Citas>.Endpoint = "https://localhost:7263/api/Citas";

        // 2. Obtener la lista mediante tu clase CRUD
        var citas = CRUD<Citas>.GetAll() ?? new List<Citas>();

        // 3. Crear la SelectList pasando la lista y las propiedades correctas
        // Guardamos en "IdCita" para coincidir con la vista
        ViewData["IdCita"] = new SelectList(citas, "Id_cita", "Motivo");

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