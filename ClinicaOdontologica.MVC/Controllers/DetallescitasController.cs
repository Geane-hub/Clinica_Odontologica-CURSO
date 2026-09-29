
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class DetallescitaController : Controller
{
    // GET: CONSULTORIO
    public ActionResult Index()
    {
        var detallescitas = CRUD<Detallescita>.GetAll();
        return View(detallescitas);
    }

    // GET: CONSULTORIO/Details/5
    public IActionResult Details(int id)
    {
        var consultorio = CRUD<Detallescita>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // GET: CONSULTORIO/Create
    public ActionResult Create() //si no se crea nada
    {
        return View(); //no retorna nada
    }

    // POST: CONSULTORIO/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost] //se encarga de -> reaccione solo cuando precione guardar (para guardar el dato)
    [ValidateAntiForgeryToken] //-> validacion de seguridad, que solo use los formularios que tenemos no de terceros
    public ActionResult Create(Detallescita detallescita)
    {
        //estamos creando un objeto
        try
        {
            CRUD<Detallescita>.Create(detallescita);
            return RedirectToAction(nameof(Index)); //redirigiendo a un mismo punto
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallescita);
        }
    }

    // GET: CONSULTORIO/Edit/5
    public ActionResult Edit(int id)
    {
        var consultorio = CRUD<Detallescita>.GetById(id);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIO/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Detallescita detallescita)
    {
        try
        {
            CRUD<Detallescita>.Update(id, detallescita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallescita);
        }
    }

    // GET: CONSULTORIO/Delete/5
    public ActionResult Delete(int id)
    {
        var detallescita = CRUD<Detallescita>.GetById(id);
        if (detallescita == null)
        {
            return NotFound();
        }
        return View(detallescita);
    }

    // POST: CONSULTORIO/Delete/5
    [HttpPost, ActionName("Delete")] //referencia a .net que finja que ese metodo es DELETE 
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Detallescita detallescita)
    {
        try
        {
            CRUD<Detallescita>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
