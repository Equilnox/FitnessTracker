using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Gyms",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Gym address",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Gym address");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30d1ab20-e536-48ea-aa61-2db91207a880", 0, "b30d03d4-a9d0-41aa-b0cc-4ff86047d3fb", "testOne@mail.bg", false, false, null, "testOne@mail.bg", "testOne@mail.bg", "AQAAAAEAACcQAAAAEPM51fzgUeyinpg6MZGUizfUWzXo8l12QlehGKvTpDWL0r+ygd0B4AgYK9yvwDVj5Q==", null, false, "7548d7b6-c378-4b96-9291-8471912d4acb", false, "testOne@mail.bg" },
                    { "bcde2890-ad6a-4eb9-87da-59255f3cc66a", 0, "708be3a6-fd68-4d93-861c-aea632bb2e49", "testTwo@mail.bg", false, false, null, "testTwo@mail.bg", "testTwo@mail.bg", "AQAAAAEAACcQAAAAEPO970SgzjXjRCJmPqiCJBb1CBq6iPlrlLHU31tWXxopmHc6U8FXFuzLDNuNGhgfnQ==", null, false, "b04865d4-10ee-4862-92fd-682008a30f83", false, "testTwo@mail.bg" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { 1, "The push-up (press-up in British English) is a common calisthenics exercise beginning from the prone position. By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole.", 0, "Pushups" },
                    { 2, "The bench press, or chest press, is a weight training exercise where a person presses a weight upwards while lying horizontally on a weight training bench. Although the bench press is a compound movement, the muscles primarily used are the pectoralis major, the anterior deltoids, and the triceps, among other stabilizing muscles. A barbell is generally used to hold the weight, but a pair of dumbbells can also be used.", 1, "Bench press" },
                    { 3, "The pull-down exercise is a strength training exercise designed to develop the latissimus dorsi muscle. It performs the functions of downward rotation and depression of the scapulae combined with adduction and extension of the shoulder joint.", 2, "Pull down" },
                    { 4, "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up. Squats also help the hip muscles.", 3, "Squat" },
                    { 5, "The bicep curl mainly targets the biceps brachii, brachialis and brachioradialis muscles. The biceps is stronger at elbow flexion when the forearm is supinated (palms turned upward) and weaker when the forearm is pronated.[1] The brachioradialis is at its most effective when the palms are facing inward, and the brachialis is unaffected by forearm rotation. Therefore, the degree of forearm rotation affects the degree of muscle recruitment between the three muscles.", 4, "Bicep curl" },
                    { 6, "The sit-up (or curl-up) is an abdominal endurance training exercise to strengthen, tighten and tone the abdominal muscles. It is similar to a crunch (crunches target the rectus abdominis and also work the external and internal obliques), but sit-ups have a fuller range of motion and condition additional muscles.", 5, "Sit up" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "Name", "Owner", "PhoneNumber", "PricePerMonth" },
                values: new object[] { 1, "Somewhere in the hood. Don't know this is just for testing.", "TestGymOne", "TestGymOwner", "0888888888", 40m });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "Age", "FirstName", "Height", "LastName", "ProfilePictureURL", "UserId", "Weight" },
                values: new object[] { 1, 25, "TestAthleteOneFirstName", 175, "TestAthleteOneLastName", "", "30d1ab20-e536-48ea-aa61-2db91207a880", 65.0 });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "Age", "FirstName", "Height", "LastName", "ProfilePictureURL", "UserId", "Weight" },
                values: new object[] { 2, 30, "TestAthleteTwoFirstName", 180, "TestAthleteTwoLastName", "", "bcde2890-ad6a-4eb9-87da-59255f3cc66a", 123.0 });

            migrationBuilder.InsertData(
                table: "AthletesGyms",
                columns: new[] { "AthleteId", "GymId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "AthleteId", "Date", "GymId", "WorkoutType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 2, 1, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 3, 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 4, 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 5, 1, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 6, 2, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Intensities",
                columns: new[] { "Id", "ExerciseId", "LiftedWeight", "Repetitions", "Seconds", "Sets", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 2, 40, 10, 45, 3, 1 },
                    { 2, 3, 30, 10, 45, 3, 1 },
                    { 3, 4, 50, 10, 45, 3, 1 },
                    { 4, 5, 15, 10, 45, 3, 1 },
                    { 5, 6, 30, 15, 60, 3, 1 },
                    { 6, 2, 40, 10, 45, 3, 2 },
                    { 7, 3, 30, 10, 45, 3, 2 },
                    { 8, 4, 50, 10, 45, 3, 2 },
                    { 9, 5, 15, 10, 45, 3, 2 },
                    { 10, 6, 30, 15, 60, 3, 2 },
                    { 11, 2, 40, 10, 45, 3, 3 },
                    { 12, 3, 30, 10, 45, 3, 3 },
                    { 13, 4, 50, 10, 45, 3, 3 },
                    { 14, 5, 15, 10, 45, 3, 3 },
                    { 15, 6, 30, 15, 60, 3, 3 },
                    { 16, 2, 45, 10, 45, 3, 4 },
                    { 17, 3, 35, 10, 45, 3, 4 },
                    { 18, 4, 50, 10, 45, 3, 4 },
                    { 19, 5, 15, 10, 45, 3, 4 },
                    { 20, 6, 30, 20, 60, 3, 4 },
                    { 21, 2, 45, 10, 45, 3, 5 },
                    { 22, 3, 35, 10, 45, 3, 5 },
                    { 23, 4, 50, 10, 45, 3, 5 },
                    { 24, 5, 15, 10, 45, 3, 5 },
                    { 25, 6, 30, 20, 60, 3, 5 },
                    { 26, 2, 45, 10, 45, 3, 6 },
                    { 27, 3, 35, 10, 45, 3, 6 },
                    { 28, 4, 50, 10, 45, 3, 6 },
                    { 29, 5, 15, 10, 45, 3, 6 },
                    { 30, 6, 30, 20, 60, 3, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AthletesGyms",
                keyColumns: new[] { "AthleteId", "GymId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AthletesGyms",
                keyColumns: new[] { "AthleteId", "GymId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Intensities",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30d1ab20-e536-48ea-aa61-2db91207a880");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcde2890-ad6a-4eb9-87da-59255f3cc66a");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Gym address",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Gym address");
        }
    }
}
