using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class RequestStatusAndRequestTypeConvertedToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestType",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Type of request. Can be Add Exercise = 0, Edit Exercise = 1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Type of request. Can be Add Exercise = 0, Edit Exercise = 1");

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Request status. Can be Pending = 0 or Done = 1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Request status. Can be Pending = 0, Done = 1 or Failed = 2");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseNewName",
                table: "Requests",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Property for Changing Exercise Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Property for Changing Exercise Name");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseNewDescription",
                table: "Requests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Property for Changing Exercise Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Property for Changing Exercise Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                comment: "The date the request was made. Default value is 'DateTime.Now'",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date the request was made");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fbfc681-ca77-44ec-86ff-f140b241a62c", "AQAAAAEAACcQAAAAEDRaT+HGf897kSqgm5N+pZYacZ327KCaEh0t3CovVEqLCJvP0dqsK5i3YiCNFo079w==", "ee13fcb6-c0b3-4d5b-b3a1-add11c86c1f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53ce3420-eaac-4ec9-a304-a5836196d4a0", "AQAAAAEAACcQAAAAEAN4usya7p/y9zwuV81IpfsRUXsoCColS8iZI3YUznOmOc626GwkMF8Vc94UikAcOw==", "190ffd3f-9715-445a-a9f0-81ffc19939d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e63e3e57-3880-4b04-865e-ad3a56564db7", "AQAAAAEAACcQAAAAEMYOQQH28lKl2xpW4xmMLqYU1CiIRy8yenHzLx5wN3/RsDo4GMF3WNktfti6ypXxzg==", "354d114c-5c4c-4a3b-be2f-55811262e0da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestType",
                table: "Requests",
                type: "int",
                nullable: false,
                comment: "Type of request. Can be Add Exercise = 0, Edit Exercise = 1",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Type of request. Can be Add Exercise = 0, Edit Exercise = 1");

            migrationBuilder.AlterColumn<int>(
                name: "RequestStatus",
                table: "Requests",
                type: "int",
                nullable: false,
                comment: "Request status. Can be Pending = 0, Done = 1 or Failed = 2",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Request status. Can be Pending = 0 or Done = 1");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseNewName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Property for Changing Exercise Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Property for Changing Exercise Name");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseNewDescription",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Property for Changing Exercise Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Property for Changing Exercise Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                comment: "The date the request was made",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date the request was made. Default value is 'DateTime.Now'");

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
        }
    }
}
