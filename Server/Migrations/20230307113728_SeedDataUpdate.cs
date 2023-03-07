using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://pixabay.com/get/gf9a83c63161cba0344bfff805686fb9f5a4d7947c5aae295a0944f0e0baaa247c9cbb637de52ae1349123439d8a313047351af0010af545ffd7e2411c3f33724f14768edf70fafaff0aa07c866e597df_1280.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/325594825_1452561625273197_3749631723571176120_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=RPCrtPASyDIAX9MB_xX&_nc_ht=scontent-waw1-1.xx&oh=00_AfAJiX5QePPXw7IBI7rUL9YOnu4h3EnLJ1ahB3DZ1cVBNA&oe=63D7FFC4");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/315829423_1529741864136995_8866568946256025211_n.jpg?stp=dst-jpg_p180x540&_nc_cat=105&ccb=1-7&_nc_sid=340051&_nc_ohc=WJBxHfhRbiAAX-zVYOa&_nc_ht=scontent-waw1-1.xx&oh=00_AfB2F_YjMScJ7J0hhZjb1AgUxQbYR5YMOwJ4FDFwCd5TJg&oe=63D7EE83");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/326033232_2387371144758789_8496355661206030946_n.jpg?stp=dst-jpg_s960x960&_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=WEKz1t0EdTQAX8zFbCQ&_nc_ht=scontent-waw1-1.xx&oh=00_AfCWRLHboZu7k0P7sR3iMwzXokrrJfYoQJibNDnFpdRNtQ&oe=63D6DFAD");
        }
    }
}
