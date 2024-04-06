using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddTestAthleteTwoGymTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AthletesGyms",
                columns: new[] { "AthleteId", "GymId", "EndDate", "StartDate" },
                values: new object[] { 2, 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AthletesGyms",
                keyColumns: new[] { "AthleteId", "GymId" },
                keyValues: new object[] { 2, 2 });

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
        }
    }
}
