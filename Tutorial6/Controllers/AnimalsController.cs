using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tutorial6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static readonly List<Animal> animalList = Database.Animals; // lista wszystkich zwierzat
        private static readonly List<Visit> visitList = Database.Visits;     // lista wszystkich wizyt

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> GetAll() // pobiera wszystkie zwierzeta
            => Ok(animalList);

        // GET api/animals/{animalId}
        [HttpGet("{animalId}")]
        public ActionResult<Animal> GetById(int animalId) // pobiera zwierze po id
        {
            var animal = animalList.FirstOrDefault(a => a.Id == animalId); // szuka zwierzecia
            if (animal == null) return NotFound();                     // nie znaleziono zwierzaka
            return Ok(animal);                                          // zwraca znalezione zwierze
        }

        // GET api/animals/search?name={searchName}
        [HttpGet("search")]
        public ActionResult<IEnumerable<Animal>> SearchByName([FromQuery] string searchName) // wyszukuje zwierzeta po nazwie
        {
            var matchingAnimals = animalList.Where(a => a.Name.Contains(searchName, System.StringComparison.OrdinalIgnoreCase)); // filtruje po nazwie
            return Ok(matchingAnimals); // zwraca dopasowane zwierzeta
        }

        // POST api/animals
        [HttpPost]
        public ActionResult<Animal> Create([FromBody] Animal newAnimal) // tworzy nowe zwierze
        {
            var nextId = animalList.Any() ? animalList.Max(a => a.Id) + 1 : 1; // wyznacza nastepne id
            newAnimal.Id = nextId;
            animalList.Add(newAnimal); // dodaje zwierze do listy
            return CreatedAtAction(nameof(GetById), new { animalId = newAnimal.Id }, newAnimal); // zwraca utworzone zwierze
        }

        // PUT api/animals/{animalId}
        [HttpPut("{animalId}")]
        public IActionResult Update(int animalId, [FromBody] Animal updatedAnimal) // aktualizuje dane zwierzaka
        {
            var index = animalList.FindIndex(a => a.Id == animalId); // znajduje index zwierzaka
            if (index == -1) return NotFound();                    // nie znaleziono zwierzaka
            updatedAnimal.Id = animalId;
            animalList[index] = updatedAnimal;                     // aktualizuje dane
            return NoContent();                                    // brak tresci
        }

        // DELETE api/animals/{animalId}
        [HttpDelete("{animalId}")]
        public IActionResult Delete(int animalId) // usuwa zwierze i jego wizyty
        {
            var animal = animalList.FirstOrDefault(a => a.Id == animalId); // szuka zwierzaka
            if (animal == null) return NotFound();                         // nie znaleziono zwierzaka

            visitList.RemoveAll(v => v.AnimalId == animalId); // usuwa powiazane wizyty
            animalList.Remove(animal);                         // usuwa zwierze

            return NoContent(); // brak tresci
        }
    }
}
