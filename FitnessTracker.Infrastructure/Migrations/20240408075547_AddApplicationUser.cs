using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Athletes");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a9b47a-93d3-4371-8023-b978085c5567", "TestAthleteOneFirstName", "TestAthleteOneLastName", "AQAAAAEAACcQAAAAEB0lq/I1XB58sl7pEObxqrMC6ADYnEbQBUaI1avwRMmwRq+MbeLSRSiSNj6QuuNTTA==", "3e2267e8-7ded-4a5a-a72a-f8d00393d272" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f4441e3-792c-46d7-b6e2-0335de850a6d", "Coolest", "Administrator", "AQAAAAEAACcQAAAAEM0n5/RsD3HNhTZ3XENOBvNhPVV05uzAneQBqYiGMdFJW+Ny+dpt1xr7n9SV/tbJaQ==", "0e969612-2c01-4fcd-955a-39bfe8cc28f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46f6125-150f-41ca-8c8e-715580dc77bf", "TestAthleteTwoFirstName", "TestAthleteTwoLastName", "AQAAAAEAACcQAAAAEDk70VGcfKj0hP6hk5UI927M6EvcEcTn6q9UhLtSPqZxw/h9FY+91UnhEx29MNSWZw==", "f453994a-b942-4703-95be-a0319f3fc667" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Athletes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "User first name.");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Athletes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "User last name.");

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

            migrationBuilder.UpdateData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "TestAthleteOneFirstName", "TestAthleteOneLastName" });

            migrationBuilder.UpdateData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "TestAthleteTwoFirstName", "TestAthleteTwoLastName" });

            migrationBuilder.UpdateData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Coolest", "Administrator" });
        }
    }
}
