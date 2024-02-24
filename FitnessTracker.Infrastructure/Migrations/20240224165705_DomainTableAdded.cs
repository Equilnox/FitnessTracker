using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class DomainTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "User identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "User first name."),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "User last name."),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User profile picture"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "User age."),
                    Height = table.Column<int>(type: "int", nullable: false, comment: "User height."),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "User weight."),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "User identifier.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Additional information of the user.");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Exercise identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Exercise name."),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Exercise description"),
                    MuscleGroup = table.Column<int>(type: "int", nullable: false, comment: "Exercise targeted muscle. Can be one of following: 1 = Compound move; 2 = Chest muscles; 3 = Back muscles; 4 = Legs muscles; 5 = Arms muscles; 6 = Abdominal muscles.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                },
                comment: "Exercises.");

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Gym identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Gym name."),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gym address"),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Gym owner full name."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false, comment: "Gym phone number."),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Gym membership price per month")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                },
                comment: "Available gym");

            migrationBuilder.CreateTable(
                name: "AthletesGyms",
                columns: table => new
                {
                    AthleteId = table.Column<int>(type: "int", nullable: false, comment: "Athlete identifier"),
                    GymId = table.Column<int>(type: "int", nullable: false, comment: "Gym identifier"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date od membership"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End date of membership")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletesGyms", x => new { x.AthleteId, x.GymId });
                    table.ForeignKey(
                        name: "FK_AthletesGyms_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthletesGyms_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Workout identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutType = table.Column<int>(type: "int", nullable: false, comment: "Workout type. Can be one of following: 1 = Full Body; 2 = Chest workout; 3 = Back workout; 4 = Legs workout; 5 = Arms workout; 6 = Abdominal workout; 7 = HIIT workout."),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The day of the workout"),
                    AthleteId = table.Column<int>(type: "int", nullable: false, comment: "User identifier"),
                    GymId = table.Column<int>(type: "int", nullable: false, comment: "Gym identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workouts_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Performed workout.");

            migrationBuilder.CreateTable(
                name: "Intensities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Intensity identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiftedWeight = table.Column<int>(type: "int", nullable: false, comment: "The amount of weight with witch the exercise was performed."),
                    Repetitions = table.Column<int>(type: "int", nullable: false, comment: "Number of repetition per set."),
                    Sets = table.Column<int>(type: "int", nullable: false, comment: "Number of sets performed."),
                    Seconds = table.Column<int>(type: "int", nullable: false, comment: "The average amount of seconds elapsed for completing a single set"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false, comment: "Exercise identifier."),
                    WorkoutId = table.Column<int>(type: "int", nullable: false, comment: "Workout identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intensities_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intensities_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Intensity of a performed exercise.");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_UserId",
                table: "Athletes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesGyms_GymId",
                table: "AthletesGyms",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Intensities_ExerciseId",
                table: "Intensities",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Intensities_WorkoutId",
                table: "Intensities",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_AthleteId",
                table: "Workouts",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_GymId",
                table: "Workouts",
                column: "GymId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletesGyms");

            migrationBuilder.DropTable(
                name: "Intensities");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
