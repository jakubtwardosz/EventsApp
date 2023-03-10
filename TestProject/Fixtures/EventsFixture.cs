using EventsApp.Shared;

namespace UnitTests.Fixtures
{
    public static class EventsFixture
    {
        public static List<Event> GetTestEvents() => new()
        {
                new Event
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "BASSTARDS 2.0: MATT GREEN / FATHERTZ",
                    Description = "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!",
                    ImageUrl = "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg",
                    Date = new DateTime(2023, 2, 17, 23, 00, 00),
                    Street = "Plac wolnica 10",
                    City = "Kraków",
                    Price = 7.99M
                },
               new Event
               {
                   Id = 2,
                   CategoryId = 1,
                   Title = "Digital Organism VI: Unkey & MC Toast // Powered By Ashwagundub Soundsystem // 3 Urodziny",
                   Description = "Digital Organism to cykl imprez, na których nie będziemy się z Wami pieścić. Nie obiecujemy cukierkowego klimatu. Nie zobaczycie męczących stroboli w klubie. Tylko kawał dobrej roboty muzyków oraz dekoratorów",
                   ImageUrl = "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg",
                   Date = new DateTime(2023, 2, 24, 23, 00, 00),
                   Street = "Niepodległości 36",
                   City = "Poznań",
                   Price = 8.99M
               },
               new Event
               {
                   Id = 3,
                   CategoryId = 2,
                   Title = "Bejsufka #2 | DNB | Klub Baza",
                   Description = "Siemanko dramendbejsowe świry! Tak jak obiecaliśmy - wracamy z drugą edycją bejsufki już 25 lutego w Klubie Baza! 🚀",
                   ImageUrl = "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg",
                   Date = new DateTime(2023, 2, 25, 22, 00, 00),
                   Street = "Mostowa 2",
                   City = "Kraków",
                   Price = 9.99M
               }
        };

        public static Event GetTestEvent(int id = 1) => new Event
        {
            Id = id,
            CategoryId = 1,
            Title = "BASSTARDS 2.0: MATT GREEN / FATHERTZ",
            Description = "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!",
            ImageUrl = "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg",
            Date = new DateTime(2023, 2, 17, 23, 00, 00),
            Street = "Plac wolnica 10",
            City = "Kraków",
            Price = 7.99M
        };
    }
}
