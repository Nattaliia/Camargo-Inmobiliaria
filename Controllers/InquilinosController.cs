using Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class InquilinosController : Controller
    {
            RepositorioInquilino repositorio;
            public InquilinosController()
            {
                repositorio = new RepositorioInquilino();
            }

            // GET: InquilinosController
            public ActionResult Index()
        {
            return View();
        }

        // GET: InquilinosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InquilinosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino i)
        {
            try
            {
                int res = repositorio.Alta(i);
                if (res > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: InquilinosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InquilinosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InquilinosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InquilinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
