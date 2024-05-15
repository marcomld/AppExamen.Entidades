using AppExamen.ConsumeAPI;
using AppExamen.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppExamen.WebMVC.Controllers
{
    public class ComputadorasController : Controller
    {

        private string urlApi;

        public ComputadorasController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Computadoras";
        }

        // GET: ComputadorasController
        public ActionResult Index()
        {
            var data = Crud<Computadora>.Read(urlApi);
            return View(data);
        }

        // GET: ComputadorasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Computadora>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: ComputadorasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputadorasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Computadora data)
        {
            try
            {
                var newData = Crud<Computadora>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ComputadorasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Computadora>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ComputadorasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Computadora data)
        {
            try
            {
                Crud<Computadora>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ComputadorasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Computadora>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ComputadorasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Computadora data)
        {
            try
            {
                Crud<Computadora>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
