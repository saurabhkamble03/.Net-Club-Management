using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class SquadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SquadController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Squad> objSquadList = _db.Squads;
            return View(objSquadList);
        }

        //GET
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Squad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Squads.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Update(int ? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }

            var squadToDatabase = _db.Squads.Find(id);

            if(squadToDatabase == null)
            {
                return NotFound();
            }

            return View(squadToDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Squad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Squads.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Remove(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var squadToDatabase = _db.Squads.Find(id);

            if (squadToDatabase == null)
            {
                return NotFound();
            }

            return View(squadToDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePlayer(int ? id)
        {
            var obj = _db.Squads.Find(id);
            
            if(id == null)
            {
                return NotFound();
            }
            
            _db.Squads.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            

            return View(obj);
        }
    }
}