using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Adventureworks.Data;
using Newtonsoft.Json;

namespace AdventureWorks.WEB.UI.MVC.Controllers
{
    public class CurrenciesController : Controller
    {
        // GET: CurrenciesController
        public async Task<IActionResult> Index()
        {
            List<Currency> currencyList = new List<Currency>();
            using (var httpClient = new HttpClient())
            {
                using (var  response = await httpClient.GetAsync("https://localhost:7027/api/currencies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currencyList = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);
                }

            }

            return View(currencyList);
        }

        // GET: CurrenciesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            List<Currency> currencyList = new List<Currency>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7027/api/Currencies/id?id=" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        currencyList = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);
                    }
                    else 
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }                   
                }
            }
            return View(currencyList.ElementAt(0));
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
