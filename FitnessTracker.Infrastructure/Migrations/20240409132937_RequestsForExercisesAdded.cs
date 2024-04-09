using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class RequestsForExercisesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "A boolean check that represents if the Exercise is Approved by the admin. Default value is false. When value is set to true the Exercise is shown in the page.");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the request was made"),
                    DateDone = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The date the request was processed"),
                    RequestType = table.Column<int>(type: "int", nullable: false, comment: "Type of request. Can be Add Exercise = 0, Edit Exercise = 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false, comment: "Exercise identifier"),
                    ExerciseNewName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Property for Changing Exercise Name"),
                    ExerciseNewDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Property for Changing Exercise Description"),
                    RequestStatus = table.Column<int>(type: "int", nullable: false, comment: "Request status. Can be Pending = 0, Done = 1 or Failed = 2")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be25f315-43c9-4f41-a127-425f74ebd4e9", "AQAAAAEAACcQAAAAEM9lyW0uGZJkkwB8n5z+RcIKweWJrmhJw/iwNy0IRsK538/gcshAoADtFMnK1Qi+CQ==", "cc8d509a-5f2f-4fe7-86d2-cdbf5fba72a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4cb11af-3167-4b7b-b9a8-ca05780f1989", "AQAAAAEAACcQAAAAECYAcXLErWgSVC0cJeJZEkwYHOZ8vTgYr6tl8QdgsJMg+zJywH4FOTa4l72oHEs5Bg==", "cad67636-4c84-4782-8503-94f1d095604b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "874cfc78-8bad-4368-a4c4-67e22baf4025", "AQAAAAEAACcQAAAAEGHAMFpyC3jR4NzmbGaFfUbww26IXIe46pwfB+3401mvmKU7Ivr3sk3fQ7i6gQt5Tg==", "15f26b57-2cdd-4ad2-9df2-e85a986c4a82" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApproved",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ExerciseId",
                table: "Requests",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a9b47a-93d3-4371-8023-b978085c5567", "AQAAAAEAACcQAAAAEB0lq/I1XB58sl7pEObxqrMC6ADYnEbQBUaI1avwRMmwRq+MbeLSRSiSNj6QuuNTTA==", "3e2267e8-7ded-4a5a-a72a-f8d00393d272" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f4441e3-792c-46d7-b6e2-0335de850a6d", "AQAAAAEAACcQAAAAEM0n5/RsD3HNhTZ3XENOBvNhPVV05uzAneQBqYiGMdFJW+Ny+dpt1xr7n9SV/tbJaQ==", "0e969612-2c01-4fcd-955a-39bfe8cc28f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46f6125-150f-41ca-8c8e-715580dc77bf", "AQAAAAEAACcQAAAAEDk70VGcfKj0hP6hk5UI927M6EvcEcTn6q9UhLtSPqZxw/h9FY+91UnhEx29MNSWZw==", "f453994a-b942-4703-95be-a0319f3fc667" });
        }
    }
}
