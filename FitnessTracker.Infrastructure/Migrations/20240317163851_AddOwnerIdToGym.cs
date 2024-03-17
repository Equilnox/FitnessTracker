using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddOwnerIdToGym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Gyms");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Gyms",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "Gym owner Identifier.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eac80b69-b339-4ab7-8d6a-afa49041eb93", "AQAAAAEAACcQAAAAEEfCj2GR4LfNU0py2yTP6tiDIOnjGf77Lm41m7orAboP6Q5Yh/7naQOFhGtFOEq1Bg==", "e4296859-a44a-4934-bca8-4525c2b8131f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "221a3b37-19ce-49bc-a3c9-7c2a6ca30f70", "AQAAAAEAACcQAAAAEAPQNKR8zA5WjrU2OzGVEkNhB7dAqA/eWGBkvmBUNButbLCtIIuImobYfyGjYNriFQ==", "91101aa8-87d6-4879-aa37-825a0b01bece" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: "30d1ab20-e536-48ea-aa61-2db91207a880");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_OwnerId",
                table: "Gyms",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_AspNetUsers_OwnerId",
                table: "Gyms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_AspNetUsers_OwnerId",
                table: "Gyms");

            migrationBuilder.DropIndex(
                name: "IX_Gyms_OwnerId",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Gyms");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Gyms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Gym owner full name.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b30d03d4-a9d0-41aa-b0cc-4ff86047d3fb", "AQAAAAEAACcQAAAAEPM51fzgUeyinpg6MZGUizfUWzXo8l12QlehGKvTpDWL0r+ygd0B4AgYK9yvwDVj5Q==", "7548d7b6-c378-4b96-9291-8471912d4acb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "708be3a6-fd68-4d93-861c-aea632bb2e49", "AQAAAAEAACcQAAAAEPO970SgzjXjRCJmPqiCJBb1CBq6iPlrlLHU31tWXxopmHc6U8FXFuzLDNuNGhgfnQ==", "b04865d4-10ee-4862-92fd-682008a30f83" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Owner",
                value: "TestGymOwner");
        }
    }
}
