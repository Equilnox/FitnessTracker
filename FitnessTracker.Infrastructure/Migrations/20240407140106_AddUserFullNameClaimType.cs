using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddUserFullNameClaimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "TestAthleteOneFirstName TestAthleteOneLastName", "30d1ab20-e536-48ea-aa61-2db91207a880" },
                    { 2, "user:fullname", "TestAthleteTwoFirstName TestAthleteTwoLastName", "bcde2890-ad6a-4eb9-87da-59255f3cc66a" },
                    { 3, "user:fullname", "Coolest Administrator", "99859188-64ff-41ec-a7c2-734c0a32e109" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8787e195-ad9b-4d5b-bfed-85c9ab999dc4", "AQAAAAEAACcQAAAAEEB7n5fmxxrpRFwcrYWB5Xfqx+tZVoDBGAuPw4ArJbnmWcZLCrGth2/L7FjXFtQ6GA==", "fbbcf3cf-5f11-490a-8c51-391097b0bc84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9936a69e-5fbb-4138-9731-0ffd1291f3dc", "AQAAAAEAACcQAAAAEHHQjmHQHS7bgpPD5RTlw4bktZHK4g8RUnON1iBMhIsTWcEwmh1tagyALrwBDXsWmw==", "8335dab6-bb7d-4cd2-9287-82a8da7a881f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd7de856-67f6-40fc-bd86-17759b3d6c51", "AQAAAAEAACcQAAAAEOGolG9VXn9iEWmg9WDm4Ds51IjeUTXPrsUwyReWOvSgTqTJq/poYWws1XCTAOn+lg==", "30067acb-892d-4428-a724-b6c2de6fdc22" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2a73e70-fd25-45ee-8a57-0570d6438401", "AQAAAAEAACcQAAAAEPOPDtpZmnxhWIz6qJywJpwCGcD0yPXgWO1y/CPyiaP8e0Fd+SmvMCyhQ6ikFJkbPg==", "b5ac5cab-4553-48e5-9f9d-711d61678ebb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63ba8e66-7c3b-48dc-b800-858a70686224", "AQAAAAEAACcQAAAAEKfJ62Cls3xk7eGBluB21KZTV8R5O27RMd4g0DFs3LleLD0pKAvyFX+jmW0ixE5OzA==", "6bb83188-9917-4905-b27d-84a71401ef6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a520327a-ca77-49e8-bcc4-4f790e37a3e5", "AQAAAAEAACcQAAAAEEF5c51z8DHQlXMwSdDdSeTbviUx74zlnthSyDt/VRugvW1vfrw9MmdLCpxa+om4uQ==", "e45fa27b-a10d-4e93-95f5-bd4e60740825" });
        }
    }
}
