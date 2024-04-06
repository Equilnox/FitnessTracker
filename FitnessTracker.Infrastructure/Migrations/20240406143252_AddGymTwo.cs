using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddGymTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac7498c-ce60-4580-a518-b09dba8d9a7c", "AQAAAAEAACcQAAAAEIVjWMcbKW06xa6jhz53BjZDXk11pXf188Wbm2S22HutuVQY2wZpqum1QFGF0WH4sg==", "0b6d663a-cb29-44c4-b5d7-aabe2fc44209" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae2112a9-ce61-499a-8fc9-43fec38291d7", "AQAAAAEAACcQAAAAEGztZxkJbf74qWngDQ86AaHpaSb+ej/LS5o7U5WU37n6plxpbl0LOrL0NbVqG/nwnQ==", "8f1b1176-4dd9-4091-9f8b-8329abfa66e6" });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "GymType", "Name", "OwnerId", "PhoneNumber", "PricePerMonth" },
                values: new object[] { 2, "Home", 0, "TestGymTwo", "bcde2890-ad6a-4eb9-87da-59255f3cc66a", "0888999888", 0.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e71adfd0-9918-47a6-8cdf-b10559393b62", "AQAAAAEAACcQAAAAENJLs0K3RpVq64OToiQek5TCZxxX42R/UpOmK98IZqtpRf0k0geLabcGXzaFj5sqtg==", "00c45078-c529-4f1b-b229-fbeae8b65f58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8faec87-a596-4c1a-ae74-5f59bea5e85a", "AQAAAAEAACcQAAAAEOy55adIPhEOiTMSbVT/gjwoF76lRJRrUIyx1T8BODzOX27GHh5KamGLhzuS6HkAcA==", "50703042-9774-463f-bc31-c347e125518a" });
        }
    }
}
