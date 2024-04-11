using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class ExerciseNameDescriptionMuscleGroupPropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseDescription",
                table: "Requests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "Property for current exercise description");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "Requests",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Property for current exercise name");

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroupe",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Property for current exercise muscle group");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a7b85f-2f0d-4799-806b-884718877b8a", "AQAAAAEAACcQAAAAEFjNqq+Sq4T+/kKxmAbn1OqvZkRqhuzn0IesCZ4zq5jtdXJCagx5X18siV0J/kG83w==", "3272e8c3-9994-4658-bef4-a8b00c3862cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99859188-64ff-41ec-a7c2-734c0a32e109",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95a907a8-2820-4e59-811b-90b27cc089f6", "AQAAAAEAACcQAAAAEB/vkli+fN2mpENYQpiKPk5Dt2DySWWesm+A7kMGHBgRgTqkXhV+rElqpOQbxBH+5A==", "1e811348-bf99-4882-9c4f-33147740f372" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1184b62-799a-4419-99bc-6f0f0f122ab8", "AQAAAAEAACcQAAAAEO0A1OWkX+JFf5me2FbW/QYy6f9Ew9Y+goe5yJhDBs4CBXkNbvdY2Pv9eEX0KcwTZw==", "e4821193-01d3-4d59-bfb9-31a25cd23024" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseDescription",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MuscleGroupe",
                table: "Requests");

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
    }
}
