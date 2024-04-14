using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2a73e70-fd25-45ee-8a57-0570d6438401", "AQAAAAEAACcQAAAAEPOPDtpZmnxhWIz6qJywJpwCGcD0yPXgWO1y/CPyiaP8e0Fd+SmvMCyhQ6ikFJkbPg==", "b5ac5cab-4553-48e5-9f9d-711d61678ebb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a520327a-ca77-49e8-bcc4-4f790e37a3e5", "AQAAAAEAACcQAAAAEEF5c51z8DHQlXMwSdDdSeTbviUx74zlnthSyDt/VRugvW1vfrw9MmdLCpxa+om4uQ==", "e45fa27b-a10d-4e93-95f5-bd4e60740825" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99859188-64ff-41ec-a7c2-734c0a32e109", 0, "63ba8e66-7c3b-48dc-b800-858a70686224", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEKfJ62Cls3xk7eGBluB21KZTV8R5O27RMd4g0DFs3LleLD0pKAvyFX+jmW0ixE5OzA==", null, false, "6bb83188-9917-4905-b27d-84a71401ef6a", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "Age", "FirstName", "Height", "LastName", "ProfilePictureURL", "UserId", "Weight" },
                values: new object[] { 3, 20, "Coolest", 188, "Administrator", "", "99859188-64ff-41ec-a7c2-734c0a32e109", 88.0 });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "GymType", "Name", "OwnerId", "PhoneNumber", "PricePerMonth" },
                values: new object[] { 3, "Who knows, hes the admin of the app.", 0, "Admins gym", "99859188-64ff-41ec-a7c2-734c0a32e109", "0000000000", 0.00m });

            migrationBuilder.InsertData(
                table: "AthletesGyms",
                columns: new[] { "AthleteId", "GymId", "EndDate", "StartDate" },
                values: new object[] { 3, 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AthletesGyms",
                keyColumns: new[] { "AthleteId", "GymId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c7731d8-ab21-43bb-a0b2-9ad791da6216", "AQAAAAEAACcQAAAAEEbqkWT7+89QOF6OGoS79zpH7prf9PC2+WgbSKFwBjlZmbwOmV8CZeMBfSTZOM2xAw==", "d33fb52a-386b-4c84-bf6c-f4fdbd2bb113" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29260f52-d08a-446a-a013-b061d5013a84", "AQAAAAEAACcQAAAAED+PqE348dSUVxj9+tg7dUv/6Picu4Rw8y/tPi+T45gsA5Zqyjde73kPaiFuMiQyvw==", "0a8bba89-68bd-41e9-9392-8ea4ca222166" });
        }
    }
}
