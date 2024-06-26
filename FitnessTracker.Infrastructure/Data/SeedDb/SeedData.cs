﻿using FitnessTracker.Infrastructure.Data.Constrains;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using static FitnessTracker.Infrastructure.Data.Constrains.CustomClaims;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser TestUserOne { get; set; }

        public IdentityUserClaim<string> TestUserOneClaim { get; set; }

        public ApplicationUser TestUserTwo { get; set; }

        public IdentityUserClaim<string> TestUserTwoClaim { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public Athlete TestAthleteOne { get; set; }

        public Athlete TestAthleteTwo { get; set; }

        public Athlete AdminAthlete { get; set; }

        public Exercise ExerciseOne { get; set; }

        public Exercise ExerciseTwo { get; set; }

        public Exercise ExerciseThree { get; set; }

        public Exercise ExerciseFour { get; set; }  

        public Exercise ExerciseFive { get; set; }

        public Exercise ExerciseSix { get; set; }

        public Gym GymOne { get; set; }

        public Gym GymTwo { get; set; }

        public Gym AdminGym { get; set; }

        public AthleteGym TestAthleteOneGymOne { get; set; }

        public AthleteGym TestAthleteTwoGymTwo { get; set; }

        public AthleteGym TestAthleteTwoGymOne { get; set; }

        public AthleteGym AdminAthleteGym { get; set; }

        public Workout TestWorkoutOne { get; set; }

        public Workout TestWorkoutTwo { get; set; }

        public Workout TestWorkoutThree { get; set; }

        public Workout TestWorkoutFour { get; set; }

        public Workout TestWorkoutFive { get; set; }

        public Workout TestWorkoutSix { get; set; }

        public Intensity TestIntensityOne { get; set; }

        public Intensity TestIntensityTwo { get; set; }

        public Intensity TestIntensityThree { get; set; }

        public Intensity TestIntensityFour { get; set; }

        public Intensity TestIntensityFive { get; set; }

        public Intensity TestIntensitySix { get; set; }

        public Intensity TestIntensitySeven { get; set; }

        public Intensity TestIntensityEight { get; set; }

        public Intensity TestIntensityNine { get; set; }

        public Intensity TestIntensityTen { get; set; }

        public Intensity TestIntensityEleven { get; set; }

        public Intensity TestIntensityTwelve { get; set; }

        public Intensity TestIntensityThirteen { get; set; }

        public Intensity TestIntensityFourteen { get; set; }

        public Intensity TestIntensityFifteen { get; set; }

        public Intensity TestIntensitySixteen { get; set; }

        public Intensity TestIntensitySeventeen { get; set; }

        public Intensity TestIntensityEighteen { get; set; }

        public Intensity TestIntensityNineteen { get; set; }

        public Intensity TestIntensityTwenty { get; set; }

        public Intensity TestIntensityTwentyOne { get; set; }

        public Intensity TestIntensityTwentyTwo { get; set; }

        public Intensity TestIntensityTwentyThree { get; set; }

        public Intensity TestIntensityTwentyFour { get; set; }

        public Intensity TestIntensityTwentyFive { get; set; }

        public Intensity TestIntensityTwentySix { get; set; }
        
        public Intensity TestIntensityTwentySeven { get; set; }

        public Intensity TestIntensityTwentyEight { get; set; }

        public Intensity TestIntensityTwentyNine { get; set; }

        public Intensity TestIntensityThirty { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAthletes();
            SeedExercises();
            SeedGyms();
            SeedAthletesGyms();
            SeedWorkouts();
            SeedIntensities();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            TestUserOne = new ApplicationUser
            {
                Id = "30d1ab20-e536-48ea-aa61-2db91207a880",
                UserName = "testOne@mail.bg",
                NormalizedUserName = "testOne@mail.bg",
                Email = "testOne@mail.bg",
                NormalizedEmail = "testOne@mail.bg",
                FirstName = "TestAthleteOneFirstName",
                LastName = "TestAthleteOneLastName",
            };

            TestUserOneClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                UserId = "30d1ab20-e536-48ea-aa61-2db91207a880",
                ClaimType = UserFullNameClaim,
                ClaimValue = "TestAthleteOneFirstName TestAthleteOneLastName"
            };

            TestUserOne.PasswordHash = hasher.HashPassword(TestUserOne, "Test12345");

            TestUserTwo = new ApplicationUser
            {
                Id = "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                UserName = "testTwo@mail.bg",
                NormalizedUserName = "testTwo@mail.bg",
                Email = "testTwo@mail.bg",
                NormalizedEmail = "testTwo@mail.bg",
                FirstName = "TestAthleteTwoFirstName",
                LastName = "TestAthleteTwoLastName",
            };

            TestUserTwoClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                UserId = "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                ClaimType = UserFullNameClaim,
                ClaimValue = "TestAthleteTwoFirstName TestAthleteTwoLastName"
            };

            TestUserTwo.PasswordHash = hasher.HashPassword(TestUserOne, "1234tesT");

            AdminUser = new ApplicationUser
            {
                Id = "99859188-64ff-41ec-a7c2-734c0a32e109",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Coolest",
                LastName = "Administrator",
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                UserId = "99859188-64ff-41ec-a7c2-734c0a32e109",
                ClaimType = UserFullNameClaim,
                ClaimValue = "Coolest Administrator"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin12345$");
        }

        private void SeedAthletes()
        {
            TestAthleteOne = new Athlete()
            {
                Id = 1,
                Age = 25,
                Height = 175,
                Weight = 65,
                UserId = "30d1ab20-e536-48ea-aa61-2db91207a880"
            };

            TestAthleteTwo = new Athlete()
            {
                Id = 2,
                Age = 30,
                Height = 180,
                Weight = 123,
                UserId = "bcde2890-ad6a-4eb9-87da-59255f3cc66a"
            };

            AdminAthlete = new Athlete()
            {
                Id = 3,
                Age = 20,
                Height = 188,
                Weight = 88,
                UserId = "99859188-64ff-41ec-a7c2-734c0a32e109"
            };
        }

        private void SeedExercises()
        {
            ExerciseOne = new Exercise()
            {
                Id = 1,
                Name = "Pushups",
                Description = "The push-up (press-up in British English) is a common calisthenics exercise beginning from the prone position. By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole.",
                MuscleGroup = MuscleGroup.CompoundMove,
                IsApproved = true
            };

            ExerciseTwo = new Exercise()
            {
                Id = 2,
                Name = "Bench press",
                Description = "The bench press, or chest press, is a weight training exercise where a person presses a weight upwards while lying horizontally on a weight training bench. Although the bench press is a compound movement, the muscles primarily used are the pectoralis major, the anterior deltoids, and the triceps, among other stabilizing muscles. A barbell is generally used to hold the weight, but a pair of dumbbells can also be used.",
                MuscleGroup = MuscleGroup.ChestMuscles,
                IsApproved = true
            };

            ExerciseThree = new Exercise()
            {
                Id = 3,
                Name = "Pull down",
                Description = "The pull-down exercise is a strength training exercise designed to develop the latissimus dorsi muscle. It performs the functions of downward rotation and depression of the scapulae combined with adduction and extension of the shoulder joint.",
                MuscleGroup = MuscleGroup.BackMuscles,
                IsApproved = true
            };

            ExerciseFour = new Exercise()
            {
                Id = 4,
                Name = "Squat",
                Description = "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up. Squats also help the hip muscles.",
                MuscleGroup = MuscleGroup.LegsMuscles,
                IsApproved = true
            };

            ExerciseFive = new Exercise()
            {
                Id = 5,
                Name = "Bicep curl",
                Description = "The bicep curl mainly targets the biceps brachii, brachialis and brachioradialis muscles. The biceps is stronger at elbow flexion when the forearm is supinated (palms turned upward) and weaker when the forearm is pronated.[1] The brachioradialis is at its most effective when the palms are facing inward, and the brachialis is unaffected by forearm rotation. Therefore, the degree of forearm rotation affects the degree of muscle recruitment between the three muscles.",
                MuscleGroup = MuscleGroup.ArmsMuscles,
                IsApproved = true
            };

            ExerciseSix = new Exercise()
            {
                Id = 6,
                Name = "Sit up",
                Description = "The sit-up (or curl-up) is an abdominal endurance training exercise to strengthen, tighten and tone the abdominal muscles. It is similar to a crunch (crunches target the rectus abdominis and also work the external and internal obliques), but sit-ups have a fuller range of motion and condition additional muscles.",
                MuscleGroup = MuscleGroup.AbdominalMuscles,
                IsApproved = true
            };
        }

        private void SeedGyms()
        {
            GymOne = new Gym()
            {
                Id = 1,
                Name = "TestGymOne",
                OwnerId = "30d1ab20-e536-48ea-aa61-2db91207a880",
                Address = "Somewhere in the hood. Don't know this is just for testing.",
                PhoneNumber = "0888888888",
                PricePerMonth = 40,
                GymType = GymType.Public
            };

            GymTwo = new Gym()
            {
                Id = 2,
                Name = "TestGymTwo",
                OwnerId = "bcde2890-ad6a-4eb9-87da-59255f3cc66a",
                Address = "Home",
                PhoneNumber = "0888999888",
                PricePerMonth = 0.00m,
                GymType = GymType.Personal
            };

            AdminGym = new Gym()
            {
                Id = 3,
                Name = "Admins gym",
                OwnerId = "99859188-64ff-41ec-a7c2-734c0a32e109",
                Address = "Who knows, hes the admin of the app.",
                PhoneNumber = "0000000000",
                PricePerMonth = 0.00m,
                GymType = GymType.Personal
            };
        }

        private void SeedAthletesGyms()
        {
            var formatProvider = DataConstrains.DateFormat;
            var cultureInfo = CultureInfo.InvariantCulture;

            TestAthleteOneGymOne = new AthleteGym()
            {
                AthleteId = TestAthleteOne.Id,
                GymId = GymOne.Id,
                StartDate = DateTime.ParseExact("01/02/2024", formatProvider, cultureInfo),
                EndDate = DateTime.ParseExact("01/03/2024", formatProvider, cultureInfo)
            };

            TestAthleteTwoGymOne = new AthleteGym()
            {
                AthleteId = TestAthleteTwo.Id,
                GymId = GymOne.Id,
                StartDate = DateTime.ParseExact("05/02/2024", formatProvider, cultureInfo),
                EndDate = DateTime.ParseExact("05/03/2024", formatProvider, cultureInfo)
            };

			TestAthleteTwoGymTwo = new AthleteGym()
			{
				AthleteId = TestAthleteTwo.Id,
				GymId = GymTwo.Id,
				StartDate = DateTime.ParseExact("05/02/2024", formatProvider, cultureInfo),
				EndDate = DateTime.ParseExact("05/03/2024", formatProvider, cultureInfo)
			};

            AdminAthleteGym = new AthleteGym()
            {
                AthleteId = AdminAthlete.Id,
                GymId = AdminGym.Id,
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
            };
		}

        private void SeedWorkouts()
        {
            var formatProvider = DataConstrains.DateFormat;
            var cultureInfo = CultureInfo.InvariantCulture;

            TestWorkoutOne = new Workout()
            {
                Id = 1,
                AthleteId = TestAthleteOne.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("01/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };

            TestWorkoutTwo = new Workout()
            {
                Id = 2,
                AthleteId = TestAthleteOne.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("03/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };

            TestWorkoutThree = new Workout()
            {
                Id = 3,
                AthleteId = TestAthleteOne.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("05/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };

            TestWorkoutFour = new Workout()
            {
                Id = 4,
                AthleteId = TestAthleteTwo.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("05/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };

            TestWorkoutFive = new Workout()
            {
                Id = 5,
                AthleteId = TestAthleteOne.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("07/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };

            TestWorkoutSix = new Workout()
            {
                Id = 6,
                AthleteId = TestAthleteTwo.Id,
                GymId = GymOne.Id,
                Date = DateTime.ParseExact("07/02/2024", formatProvider, cultureInfo),
                WorkoutType = WorkoutType.FullBody
            };
        }

        private void SeedIntensities()
        {
            TestIntensityOne = new Intensity()
            {
                Id = 1,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 40,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutOne.Id
            };

            TestIntensityTwo = new Intensity()
            {
                Id = 2,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 30,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutOne.Id
            };

            TestIntensityThree = new Intensity()
            {
                Id = 3,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutOne.Id
            };

            TestIntensityFour = new Intensity()
            {
                Id = 4,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutOne.Id
            };

            TestIntensityFive = new Intensity()
            {
                Id = 5,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 15,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutOne.Id
            };

            TestIntensitySix = new Intensity()
            {
                Id = 6,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 40,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutTwo.Id
            };

            TestIntensitySeven = new Intensity()
            {
                Id = 7,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 30,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutTwo.Id
            };

            TestIntensityEight = new Intensity()
            {
                Id = 8,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutTwo.Id
            };

            TestIntensityNine = new Intensity()
            {
                Id = 9,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutTwo.Id
            };

            TestIntensityTen = new Intensity()
            {
                Id = 10,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 15,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutTwo.Id
            };

            TestIntensityEleven = new Intensity()
            {
                Id = 11,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 40,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutThree.Id
            };

            TestIntensityTwelve = new Intensity()
            {
                Id = 12,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 30,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutThree.Id
            };

            TestIntensityThirteen = new Intensity()
            {
                Id = 13,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutThree.Id
            };

            TestIntensityFourteen = new Intensity()
            {
                Id = 14,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutThree.Id
            };

            TestIntensityFifteen = new Intensity()
            {
                Id = 15,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 15,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutThree.Id
            };

            TestIntensitySixteen = new Intensity()
            {
                Id = 16,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 45,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFour.Id
            };

            TestIntensitySeventeen = new Intensity()
            {
                Id = 17,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 35,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFour.Id
            };

            TestIntensityEighteen = new Intensity()
            {
                Id = 18,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFour.Id
            };

            TestIntensityNineteen = new Intensity()
            {
                Id = 19,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFour.Id
            };

            TestIntensityTwenty = new Intensity()
            {
                Id = 20,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 20,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutFour.Id
            };

            TestIntensityTwentyOne = new Intensity()
            {
                Id = 21,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 45,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFive.Id
            };

            TestIntensityTwentyTwo = new Intensity()
            {
                Id = 22,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 35,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFive.Id
            };

            TestIntensityTwentyThree = new Intensity()
            {
                Id = 23,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFive.Id
            };

            TestIntensityTwentyFour = new Intensity()
            {
                Id = 24,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutFive.Id
            };

            TestIntensityTwentyFive = new Intensity()
            {
                Id = 25,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 20,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutFive.Id
            };

            TestIntensityTwentySix = new Intensity()
            {
                Id = 26,
                ExerciseId = ExerciseTwo.Id,
                LiftedWeight = 45,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutSix.Id
            };

            TestIntensityTwentySeven = new Intensity()
            {
                Id = 27,
                ExerciseId = ExerciseThree.Id,
                LiftedWeight = 35,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutSix.Id
            };

            TestIntensityTwentyEight = new Intensity()
            {
                Id = 28,
                ExerciseId = ExerciseFour.Id,
                LiftedWeight = 50,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutSix.Id
            };

            TestIntensityTwentyNine = new Intensity()
            {
                Id = 29,
                ExerciseId = ExerciseFive.Id,
                LiftedWeight = 15,
                Repetitions = 10,
                Sets = 3,
                Seconds = 45,
                WorkoutId = TestWorkoutSix.Id
            };

            TestIntensityThirty = new Intensity()
            {
                Id = 30,
                ExerciseId = ExerciseSix.Id,
                LiftedWeight = 30,
                Repetitions = 20,
                Sets = 3,
                Seconds = 60,
                WorkoutId = TestWorkoutSix.Id
            };
        }
    }
}
