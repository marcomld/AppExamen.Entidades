using AppExamen.ConsumeAPI;
using AppExamen.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppExamen.WebMVC.Controllers
{
    public class SoftwaresController : Controller
    {
        private string urlApi;

        public SoftwaresController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Softwares";
        }


        // GET: SoftwaresController
        public ActionResult Index()
        {
            var data = Crud<Software>.Read(urlApi);
            return View(data);
        }

        // GET: SoftwaresController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Software>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: SoftwaresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoftwaresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Software data)
        {
            try
            {
                var newData = Crud<Software>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: SoftwaresController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Software>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: SoftwaresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Software data)
        {
            try
            {
                Crud<Software>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: SoftwaresController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Software>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: SoftwaresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Software data)
        {
            try
            {
                Crud<Software>.Delete(urlApi, id);
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
