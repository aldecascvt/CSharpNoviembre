using Microsoft.AspNetCore.Mvc;
using Adventureworks.Data;
using Newtonsoft.Json;

namespace AdventureWorks.UI.Web.MVC.Controllers
{
    public class CurrenciesController : Controller
    {
        // GET: CurrenciesController
        public async ActionResult Index()
        {
            List<Currency> currencies = new List<Currency>();

            using (var httpClient = new HttpClient())
            {
                using (var  response = httpClient.GetAsync("https://localhost:7027/api/currencies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currencies = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);
                }               

            }

            return View(currencies);
        }

        // GET: CurrenciesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CurrenciesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrenciesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CurrenciesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurrenciesController/Edit/5
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

        // GET: CurrenciesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurrenciesController/Delete/5
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
