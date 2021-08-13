using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Challenge.BGLobal.Context;
using Challenge.BGLobal.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Challenge.BGLobal.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly BGlobalContext _context;

        public VehiclesController(BGlobalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bGlobalContext = _context.Vehicles;
            return View(await bGlobalContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public IActionResult Create()
        {
            int page1 = 1;
            int page2 = 2;

            List<string> brands = new()
            {
                "Ford", "Fiat", "Peugeot", "Mercedes Benz", "Audi", "BMW", "Renault"
            };
            List<string> titulars = new();

            ListTitular(titulars, page1);
            ListTitular(titulars, page2);

            ViewData["Brands"] = new SelectList(brands);
            ViewData["Titulars"] = new SelectList(titulars);
            return View();
        }

        public void ListTitular(List<string> titulars, int numeroPag )
        {
            var url = "https://reqres.in/api/users?page=";

            HttpWebRequest request = WebRequest.Create($"{url}{numeroPag}") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();

                var jsonResponse = JsonConvert.DeserializeObject<ApiResponse>(resp);

                foreach (var titular in jsonResponse.data)
                {
                    titulars.Add(titular.first_name + " " + titular.last_name);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Patent,Brand,Model,Doors,Titular")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            int page1 = 1;
            int page2 = 2;

            List<string> brands = new()
            {
                "Ford",
                "Fiat",
                "Peugeot",
                "Mercedes Benz",
                "Audi",
                "BMW",
                "Renault"
            };
            List<string> titulars = new();

            ListTitular(titulars, page1);
            ListTitular(titulars, page2);

            ViewData["Brands"] = new SelectList(brands);
            ViewData["Titulars"] = new SelectList(titulars);

            return View(vehicle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            int page1 = 1;
            int page2 = 2;

            List<string> brands = new()
            {
                "Ford",
                "Fiat",
                "Peugeot",
                "Mercedes Benz",
                "Audi",
                "BMW",
                "Renault"
            };
            List<string> titulars = new();

            ListTitular(titulars, page1);
            ListTitular(titulars, page2);

            ViewData["Brands"] = new SelectList(brands);
            ViewData["Titulars"] = new SelectList(titulars);

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Patent,Brand,Model,Doors,Titular")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            int page1 = 1;
            int page2 = 2;

            List<string> brands = new()
            {
                "Ford",
                "Fiat",
                "Peugeot",
                "Mercedes Benz",
                "Audi",
                "BMW",
                "Renault"
            };
            List<string> titulars = new();

            ListTitular(titulars, page1);
            ListTitular(titulars, page2);

            ViewData["Brands"] = new SelectList(brands);
            ViewData["Titulars"] = new SelectList(titulars);

            return View(vehicle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
