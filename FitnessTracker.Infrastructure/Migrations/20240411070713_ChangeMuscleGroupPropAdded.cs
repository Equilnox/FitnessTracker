using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class ChangeMuscleGroupPropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeMuscleGroup",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Property for changing exercise targeted muscle group");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17b7e08c-5f3e-4c09-84a3-9d76551141b8", "AQAAAAEAACcQAAAAEPHFuixpiyC7CsSj1Sabk+QLwPZr3DT7E8MOY4moYgEIIPiYp288+MRwYMWad+o6wg==", "74a34498-7980-4174-9f2c-4a703d18b1b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "351dcdf0-7eab-4492-bbed-91c2ebb492b6", "AQAAAAEAACcQAAAAEN9weEL0NgREsBOgRCxb/5ip7ldVujqsx5bIrkWxuBk0fvLYTErqTLOg3WdaXUh03A==", "28b582e4-c85c-4c22-9b10-bc2856306d75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "275c8266-99af-4579-bc32-5bab1e4c51d0", "AQAAAAEAACcQAAAAEMRSwBD/fzfBYVmuMMX3H3t5aoAXgGcQ+tSNwlVdNIhFL6QXv4g5Fxf6SH4sUk7kqw==", "e364a272-df83-4863-b466-04cbdd45cf67" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeMuscleGroup",
                table: "Requests");

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
    }
}
