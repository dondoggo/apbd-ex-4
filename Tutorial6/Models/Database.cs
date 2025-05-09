namespace Tutorial6.Models
{
    public static class Database
    {
        public static List<Animal> Animals { get; } = new() // lista zwierzat
        {
            new Animal { Id = 1, Name = "Tommy", Category = "Dog", Weight = 15.50, FurColor = "Brown" },
            new Animal { Id = 2, Name = "Lily", Category = "Cat", Weight = 5.90, FurColor = "Red" }
        };

        public static List<Visit> Visits { get; } = new() // lista wizyt
        {
            new Visit { Id = 1, AnimalId = 1, Date = DateTime.Now.AddDays(-1), Description = "Vaccination", Price = 500 },
            new Visit { Id = 2, AnimalId = 2, Date = DateTime.Now.AddDays(-3), Description = "Control", Price = 250 }
        };
    }
}