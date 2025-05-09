using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tutorial6.Controllers
{
    [ApiController]
    [Route("api/animals/{animalId}/visits")]
    public class VisitsController : ControllerBase
    {
        private static readonly List<Animal> animalList = Database.Animals; // lista zwierzat
        private static readonly List<Visit> visitList  = Database.Visits;   // lista wizyt

        // GET api/animals/{animalId}/visits
        [HttpGet]
        public ActionResult<IEnumerable<Visit>> GetVisitsForAnimal(int animalId) // pobiera wizyty zwierzaka
        {
            if (!animalList.Any(a => a.Id == animalId)) // sprawdza czy zwierze istnieje
                return NotFound();                       // nie znaleziono zwierzaka

            var visitsForAnimal = visitList.Where(v => v.AnimalId == animalId); // filtruje wizyty po id zwierzaka
            return Ok(visitsForAnimal); // zwraca liste wizyt
        }

        // POST api/animals/{animalId}/visits
        [HttpPost]
        public ActionResult<Visit> CreateVisit(int animalId, [FromBody] Visit newVisit) // tworzy nowa wizyte
        {
            if (!animalList.Any(a => a.Id == animalId)) // sprawdza czy zwierze istnieje
                return NotFound();                       // nie znaleziono zwierzaka

            var nextId = visitList.Any() ? visitList.Max(v => v.Id) + 1 : 1; // wyznacza nastepne id wizyty
            newVisit.Id = nextId;
            newVisit.AnimalId = animalId;                                     // ustawia powiazanie z zwierzakiem
            visitList.Add(newVisit);                                          // dodaje wizyte

            return CreatedAtAction(
                nameof(GetVisitsForAnimal), new { animalId }, newVisit); // zwraca utworzone dane
        }
    }
}