
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class ConsultorioController : Controller
{
    // GET: CONSULTORIO
    public ActionResult Index()
    {
        var consultorio = CRUD<Consultorio>.GetAll();
        return View(consultorio);
    }

    // GET: CONSULTORIO/Details/5
    public IActionResult Details(int id_consultorio)
    {
        var consultorio = CRUD<Consultorio>.GetById(id_consultorio);
        if (id_consultorio == null)
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
    public ActionResult Create(Consultorio consultorio)
    {
        //estamos creando un objeto
        try
        {
            CRUD<Consultorio>.Create(consultorio);
            return RedirectToAction(nameof(Index)); //redirigiendo a un mismo punto
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CONSULTORIO/Edit/5
    public ActionResult Edit(int id_consultorio)
    {
        var consultorio = CRUD<Consultorio>.GetById(id_consultorio);
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
    public ActionResult Edit(int id_consultorio, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Update(id_consultorio,consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CONSULTORIO/Delete/5
    public ActionResult Delete(int id_consultorio)
    {
        var consultorio = CRUD<Consultorio>.GetById(id_consultorio);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIO/Delete/5
    [HttpPost, ActionName("Delete")] //referencia a .net que finja que ese metodo es DELETE 
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_consultorio, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Delete(id_consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
