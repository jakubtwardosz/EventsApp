using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class EventSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Address", "City", "Description", "ImageUrl", "Price", "StartDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "ul. Plac Wolnica 10", "Kraków", "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!", "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/325594825_1452561625273197_3749631723571176120_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=RPCrtPASyDIAX9MB_xX&_nc_ht=scontent-waw1-1.xx&oh=00_AfAJiX5QePPXw7IBI7rUL9YOnu4h3EnLJ1ahB3DZ1cVBNA&oe=63D7FFC4", 7.99m, new DateTime(2023, 2, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), "BASSTARDS 2.0: MATT GREEN / FATHERTZ", 1 },
                    { 2, "Niepodległości 36", "Poznań", "Digital Organism to cykl imprez, na których nie będziemy się z Wami pieścić. Nie obiecujemy cukierkowego klimatu. Nie zobaczycie męczących stroboli w klubie. Tylko kawał dobrej roboty muzyków oraz dekoratorów", "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/315829423_1529741864136995_8866568946256025211_n.jpg?stp=dst-jpg_p180x540&_nc_cat=105&ccb=1-7&_nc_sid=340051&_nc_ohc=WJBxHfhRbiAAX-zVYOa&_nc_ht=scontent-waw1-1.xx&oh=00_AfB2F_YjMScJ7J0hhZjb1AgUxQbYR5YMOwJ4FDFwCd5TJg&oe=63D7EE83", 8.99m, new DateTime(2023, 2, 24, 23, 0, 0, 0, DateTimeKind.Unspecified), "Digital Organism VI: Unkey & MC Toast // Powered By Ashwagundub Soundsystem // 3 Urodziny", 2 },
                    { 3, "Mostowa 2", "Kraków", "Siemanko dramendbejsowe świry! Tak jak obiecaliśmy - wracamy z drugą edycją bejsufki już 25 lutego w Klubie Baza! 🚀", "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/326033232_2387371144758789_8496355661206030946_n.jpg?stp=dst-jpg_s960x960&_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=WEKz1t0EdTQAX8zFbCQ&_nc_ht=scontent-waw1-1.xx&oh=00_AfCWRLHboZu7k0P7sR3iMwzXokrrJfYoQJibNDnFpdRNtQ&oe=63D6DFAD", 9.99m, new DateTime(2023, 2, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), "Bejsufka #2 | DNB | Klub Baza", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
