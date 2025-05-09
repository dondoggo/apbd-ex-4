namespace Tutorial6.Models
{
    public class Animal
    {
        public int Id { get; set; }               // unikalne id zwierzaka
        public string Name { get; set; } = default!;   // nazwa zwierzaka
        public string Category { get; set; } = default!; // kategoria zwierzaka
        public double Weight { get; set; }         // waga zwierzaka w kg
        public string FurColor { get; set; } = default!; // kolor sierci zwierzaka
    }
}