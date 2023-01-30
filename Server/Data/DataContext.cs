global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventsApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
               new Address
               {
                   Id = 1,
                   EventId = 1,
                   Street = "Plac wolnica 10",
                   City = "Kraków"
               },
               new Address
               {
                   Id = 2,
                   EventId = 2,
                   Street = "Niepodległości 36",
                   City = "Poznań"
               },
               new Address
               {
                   Id = 3,
                   EventId = 3,
                   Street = "Mostowa 2",
                   City = "Kraków"
               });

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "BASSTARDS 2.0: MATT GREEN / FATHERTZ",
                    Description = "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!",
                    ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/325594825_1452561625273197_3749631723571176120_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=RPCrtPASyDIAX9MB_xX&_nc_ht=scontent-waw1-1.xx&oh=00_AfAJiX5QePPXw7IBI7rUL9YOnu4h3EnLJ1ahB3DZ1cVBNA&oe=63D7FFC4",
                    Date = new DateTime(2023, 2, 17, 23, 00, 00),
                    AddressId = 1,
                    Price = 7.99M
                },
               new Event
               {
                   Id = 2,
                   CategoryId = 1,
                   Title = "Digital Organism VI: Unkey & MC Toast // Powered By Ashwagundub Soundsystem // 3 Urodziny",
                   Description = "Digital Organism to cykl imprez, na których nie będziemy się z Wami pieścić. Nie obiecujemy cukierkowego klimatu. Nie zobaczycie męczących stroboli w klubie. Tylko kawał dobrej roboty muzyków oraz dekoratorów",
                   ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/315829423_1529741864136995_8866568946256025211_n.jpg?stp=dst-jpg_p180x540&_nc_cat=105&ccb=1-7&_nc_sid=340051&_nc_ohc=WJBxHfhRbiAAX-zVYOa&_nc_ht=scontent-waw1-1.xx&oh=00_AfB2F_YjMScJ7J0hhZjb1AgUxQbYR5YMOwJ4FDFwCd5TJg&oe=63D7EE83",
                   Date = new DateTime(2023, 2, 24, 23, 00, 00),
                   AddressId = 2,
                   Price = 8.99M
               },
               new Event
               {
                   Id = 3,
                   CategoryId = 2,
                   Title = "Bejsufka #2 | DNB | Klub Baza",
                   Description = "Siemanko dramendbejsowe świry! Tak jak obiecaliśmy - wracamy z drugą edycją bejsufki już 25 lutego w Klubie Baza! 🚀",
                   ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/326033232_2387371144758789_8496355661206030946_n.jpg?stp=dst-jpg_s960x960&_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=WEKz1t0EdTQAX8zFbCQ&_nc_ht=scontent-waw1-1.xx&oh=00_AfCWRLHboZu7k0P7sR3iMwzXokrrJfYoQJibNDnFpdRNtQ&oe=63D6DFAD",
                   Date = new DateTime(2023, 2, 25, 22, 00, 00),
                   AddressId = 3,
                   Price = 9.99M
               });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Dubstep",
                    Url = "dubstep"
                },
                new Category
                {
                    Id = 2,
                    Name = "Drum and bass",
                    Url = "drum-and-bass"
                });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=eventapp;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}