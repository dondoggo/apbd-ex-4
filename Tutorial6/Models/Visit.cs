namespace Tutorial6.Models;

public class Visit
{
    public int Id { get; set; }               // unikalne id wizyty
    public int AnimalId { get; set; }         // id zwierzaka powiazane z wizyta
    public DateTime Date { get; set; }        // data wizyty
    public string Description { get; set; } = null!; // opis wizyty
    public decimal Price { get; set; }        // koszt wizyty
}