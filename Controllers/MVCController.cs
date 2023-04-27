using SCCRUMMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SCCRUMMvc.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        HttpClient client = new HttpClient();
        public async Task<ActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.GetAsync("WebApi");
            await response;

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                await display;
                productList = display.Result;
            }
            return View(productList);
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product p)
        {
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = await client.PostAsJsonAsync<Product>("WebApi",p);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Details (int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.GetAsync("WebApi?id="+id.ToString());
            await response;

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                await display;
                p = display.Result;
            }
            return View(p);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.GetAsync("WebApi?id=" + id.ToString());
            await response;

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                await display;
                p = display.Result;
            }
            return View(p);

        }


        [HttpPost]
        public async Task<ActionResult> Edit(Product p)
        {
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = await client.PutAsJsonAsync<Product>("WebApi", p);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            Product p = null;
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.GetAsync("WebApi?id=" + id.ToString());
            await response;

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                await display;
                p = display.Result;
            }
            return View(p);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(int id)
        {

            Product p = null;
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.DeleteAsync("WebApi/" + id.ToString());
            await response;

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }
            return View("Delete");
        }

        public async Task<ActionResult> ChartDashboard()
        {

            
            return View();

        }

        public async Task<ActionResult> ShowChartDashboard()
        {

            List<Product> productList = new List<Product>();
            client.BaseAddress = new Uri("https://localhost:44337/api/WebApi");
            var response = client.GetAsync("WebApi");
            await response;

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                await display;
                productList = display.Result;
            }

            var data = new List<object>();

            data.Add(new { priceRange = "0-1000", Count = productList.Count(p => p.Price >= 0 && p.Price < 1000) });
            data.Add(new { priceRange = "1001-2000", Count = productList.Count(p => p.Price >= 1001 && p.Price < 2000) });
            data.Add(new { priceRange = "2001-3000", Count = productList.Count(p => p.Price >= 2001 && p.Price < 3000) });
            data.Add(new { priceRange = "3001-4000", Count = productList.Count(p => p.Price >= 3001 && p.Price < 4000) });
            data.Add(new { priceRange = "4001-5000", Count = productList.Count(p => p.Price >= 4001 && p.Price < 5000) });

            return Json(data, JsonRequestBehavior.AllowGet);

        }




    }
}