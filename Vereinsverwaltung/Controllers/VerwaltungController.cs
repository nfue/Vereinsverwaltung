using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vereinsverwaltung.Data;
using Vereinsverwaltung.Models;

namespace Vereinsverwaltung.Controllers
{
    public class VerwaltungController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public VerwaltungController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Interessengruppen()
        {
            var interessengruppen = _context.Interessengruppen.ToList();
            ViewBag.Interessengruppen = interessengruppen;
            return View();
        }

        public IActionResult CreateEdit(int id)
        {
            return View("CreateEditInteressengruppen");
        }

        [HttpPost]
        public IActionResult CreateEditInteressengruppen(Interessengruppe interessengruppe)
        {
            _context.Interessengruppen.Add(interessengruppe);
            _context.SaveChanges();

            return RedirectToAction("Interessengruppen");
        }

        public IActionResult Mitgliedschaften()
        {
            var mitgliedschaften=_context.Mitgliedschaften.ToList();
            ViewBag.Mitgliedschaften = mitgliedschaften;
            return View();
        }

        public IActionResult Gruppenteilnehmer()
        {
            var query = (from m in _context.Mitgliedschaften
                        join i in _context.Interessengruppen on m.IdInteressengruppe equals i.Id
                        select new Gruppenteilnehmer
                        {
                            Id=m.Id,
                            Username = m.Username,
                            Interessengruppe = i.Name
                        }).ToList();
            return View(query);
        }
    }
}
