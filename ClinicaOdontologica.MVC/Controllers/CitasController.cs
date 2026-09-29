
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using Clinica_odontologia.Models01;

public class CitasController : Controller
{


    // GET: CITASS
    public ActionResult Index()    
    {
        var citas = CRUD<Citas> .GetAll();
        return View(citas);
    }

    // GET: CITASS/Details/5
    public IActionResult Details(int id_cita)
    {
        var cita = CRUD < Citas > .GetById(id_cita);
        if (id_cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // GET: CITASS/Create
    public ActionResult Create() //si no se crea nada
    {
        return View(); //no retorna nada
    }

    // POST: CITASS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost] //se encarga de -> reaccione solo cuando precione guardar (para guardar el dato)
    [ValidateAntiForgeryToken] //-> validacion de seguridad, que solo use los formularios que tenemos no de terceros
    public ActionResult Create(Citas citas)
    {
        //estamos creando un objeto
        try
        {
            CRUD<Citas>.Create(citas);
            return RedirectToAction(nameof(Index)); //redirigiendo a un mismo punto
        }
        catch (Exception ex) 
        { 
                ModelState.AddModelError("", ex.Message);
                return View(citas);
        }
    }

    // GET: CITASS/Edit/5
    public ActionResult Edit(int id_cita)
    {
        var cita = CRUD < Citas > .GetById(id_cita);
        if(cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITASS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_cita, Citas citas)
    {
        try
        {
            CRUD<Citas>.Update(id_cita,citas);
            return RedirectToAction(nameof (Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(citas);
        }
    }

    // GET: CITASS/Delete/5
    public ActionResult Delete(int id_cita)
    {
        var citas = CRUD<Citas>.GetById(id_cita);
        if(citas == null)
        {
            return NotFound();
        }
        return View(citas);
    }

    // POST: CITASS/Delete/5
    [HttpPost, ActionName("Delete")] //referencia a .net que finja que ese metodo es DELETE 
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id_cita, Citas citas)
    {
        try
        {
            CRUD<Citas>.Delete(id_cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex){
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
