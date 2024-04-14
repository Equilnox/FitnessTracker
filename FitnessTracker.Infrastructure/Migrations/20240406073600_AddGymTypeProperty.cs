using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class AddGymTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymType",
                table: "Gyms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Gym type. Can be one of following: 0 = Personal; 1 = Public.");

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "int",
                nullable: false,
                comment: "Exercise targeted muscle. Can be one of following: 0 = Compound move; 1 = Chest muscles; 2 = Back muscles; 3 = Legs muscles; 4 = Arms muscles; 5 = Abdominal muscles.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Exercise targeted muscle. Can be one of following: 1 = Compound move; 2 = Chest muscles; 3 = Back muscles; 4 = Legs muscles; 5 = Arms muscles; 6 = Abdominal muscles.");

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

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1,
                column: "GymType",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GymType",
                table: "Gyms");

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "int",
                nullable: false,
                comment: "Exercise targeted muscle. Can be one of following: 1 = Compound move; 2 = Chest muscles; 3 = Back muscles; 4 = Legs muscles; 5 = Arms muscles; 6 = Abdominal muscles.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Exercise targeted muscle. Can be one of following: 0 = Compound move; 1 = Chest muscles; 2 = Back muscles; 3 = Legs muscles; 4 = Arms muscles; 5 = Abdominal muscles.");

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
        }
    }
}
