using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Vereinsverwaltung.Data;
using Vereinsverwaltung.Models;

namespace Vereinsverwaltung.Controllers
{
    [Authorize]
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

        public IActionResult CreateEditMitgliedschaften_(int id)
        {
            var items = _context.Interessengruppen.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).OrderBy(x => x.Text).ToList();

            ViewBag.Items = items;

            if (id == 0)
            {
                return View("CreateEditMitgliedschaften");
            }

            var mitgliedschaftindb = _context.Mitgliedschaften.Find(id);

            if (mitgliedschaftindb == null)
            {
                return NotFound();
            }

            return View("CreateEditMitgliedschaften", mitgliedschaftindb);
        }

        [HttpPost]
        public IActionResult CreateEditMitgliedschaften(Mitgliedschaft mitgliedschaft)
        {
            if (mitgliedschaft.Id == 0)
            {
                _context.Mitgliedschaften.Add(mitgliedschaft);
            }
            else
            {
                _context.Mitgliedschaften.Update(mitgliedschaft);
            }
            _context.SaveChanges();

            return RedirectToAction("Mitgliedschaften");
        }

        public IActionResult DeleteMitgliedschaften(int id)
        {
            var mitgliedschaftindb = _context.Mitgliedschaften.Find(id);

            if (mitgliedschaftindb == null)
            {
                return NotFound();
            }

            _context.Mitgliedschaften.Remove(mitgliedschaftindb);
            _context.SaveChanges();

            return RedirectToAction("Mitgliedschaften");
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
