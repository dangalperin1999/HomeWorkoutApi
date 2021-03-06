// <auto-generated />
using System;
using API.DataFitness;
using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.DataFitness.Migrations
{
    [DbContext(typeof(FitnessContext))]
    [Migration("20210923194151_MadeSomeUserInfoNullableInUserModel")]
    partial class MadeSomeUserInfoNullableInUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("API.DataFitness.Models.CategorisedExercise", b =>
                {
                    b.Property<long>("CategoryExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FitnessGoalId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FitnessLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Sets")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("FitnessGoalId");

                    b.HasIndex("FitnessLevelId");

                    b.ToTable("CategorisedExercises");
                });

            modelBuilder.Entity("API.DataFitness.Models.Day", b =>
                {
                    b.Property<long>("DayId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DayId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("API.DataFitness.Models.Exercise", b =>
                {
                    b.Property<long>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("API.DataFitness.Models.FitnessGoal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FitnessGoal");
                });

            modelBuilder.Entity("API.DataFitness.Models.FitnessLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FitnessLevel");
                });

            modelBuilder.Entity("API.DataFitness.Models.FoodDiet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Calories")
                        .IsRequired()
                        .HasColumnType("NUMERIC");

                    b.Property<byte[]>("FatPercent")
                        .IsRequired()
                        .HasColumnType("NUMERIC");

                    b.Property<long>("FitnessGoalId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FoodTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FitnessGoalId");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("FoodDiet");
                });

            modelBuilder.Entity("API.DataFitness.Models.FoodType", b =>
                {
                    b.Property<long>("FoodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FoodTypeId");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("API.DataFitness.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("'0001-01-01 00:00:00'");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("'0001-01-01 00:00:00'");

                    b.Property<long>("FitnessGoalId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FitnessLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FitnessGoalId");

                    b.HasIndex("FitnessLevelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.DataFitness.Models.UserDiery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DayId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("FitnessGoalId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("FitnessLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FoodDietId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("FitnessGoalId");

                    b.HasIndex("FitnessLevelId");

                    b.HasIndex("FoodDietId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiery");
                });

            modelBuilder.Entity("API.DataFitness.Models.WorkoutPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CategoryExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryExerciseId");

                    b.HasIndex("UsersId");

                    b.ToTable("WorkoutPlan");
                });

            modelBuilder.Entity("API.DataFitness.Models.CategorisedExercise", b =>
                {
                    b.HasOne("API.DataFitness.Models.Exercise", "Exercise")
                        .WithMany("CategorisedExercises")
                        .HasForeignKey("ExerciseId")
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.FitnessGoal", "FitnessGoal")
                        .WithMany("CategorisedExercises")
                        .HasForeignKey("FitnessGoalId")
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.FitnessLevel", "FitnessLevel")
                        .WithMany("CategorisedExercises")
                        .HasForeignKey("FitnessLevelId")
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("FitnessGoal");

                    b.Navigation("FitnessLevel");
                });

            modelBuilder.Entity("API.DataFitness.Models.FoodDiet", b =>
                {
                    b.HasOne("API.DataFitness.Models.FitnessGoal", "FitnessGoal")
                        .WithMany()
                        .HasForeignKey("FitnessGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.FoodType", "FoodType")
                        .WithMany("FoodDiets")
                        .HasForeignKey("FoodTypeId")
                        .IsRequired();

                    b.Navigation("FitnessGoal");

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("API.DataFitness.Models.User", b =>
                {
                    b.HasOne("API.DataFitness.Models.FitnessGoal", "FitnessGoal")
                        .WithMany("User")
                        .HasForeignKey("FitnessGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.FitnessLevel", "FitnessLevel")
                        .WithMany("User")
                        .HasForeignKey("FitnessLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessGoal");

                    b.Navigation("FitnessLevel");
                });

            modelBuilder.Entity("API.DataFitness.Models.UserDiery", b =>
                {
                    b.HasOne("API.DataFitness.Models.Day", "Day")
                        .WithMany("UserDieries")
                        .HasForeignKey("DayId")
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.FitnessGoal", null)
                        .WithMany("UserDieries")
                        .HasForeignKey("FitnessGoalId");

                    b.HasOne("API.DataFitness.Models.FitnessLevel", null)
                        .WithMany("UserDieries")
                        .HasForeignKey("FitnessLevelId");

                    b.HasOne("API.DataFitness.Models.FoodDiet", "FoodDiet")
                        .WithMany("UserDieries")
                        .HasForeignKey("FoodDietId")
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.User", "User")
                        .WithMany("UserDieries")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("FoodDiet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.DataFitness.Models.WorkoutPlan", b =>
                {
                    b.HasOne("API.DataFitness.Models.CategorisedExercise", "CategoryExercise")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("CategoryExerciseId")
                        .IsRequired();

                    b.HasOne("API.DataFitness.Models.User", "Users")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("UsersId")
                        .IsRequired();

                    b.Navigation("CategoryExercise");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.DataFitness.Models.CategorisedExercise", b =>
                {
                    b.Navigation("WorkoutPlans");
                });

            modelBuilder.Entity("API.DataFitness.Models.Day", b =>
                {
                    b.Navigation("UserDieries");
                });

            modelBuilder.Entity("API.DataFitness.Models.Exercise", b =>
                {
                    b.Navigation("CategorisedExercises");
                });

            modelBuilder.Entity("API.DataFitness.Models.FitnessGoal", b =>
                {
                    b.Navigation("CategorisedExercises");

                    b.Navigation("User");

                    b.Navigation("UserDieries");
                });

            modelBuilder.Entity("API.DataFitness.Models.FitnessLevel", b =>
                {
                    b.Navigation("CategorisedExercises");

                    b.Navigation("User");

                    b.Navigation("UserDieries");
                });

            modelBuilder.Entity("API.DataFitness.Models.FoodDiet", b =>
                {
                    b.Navigation("UserDieries");
                });

            modelBuilder.Entity("API.DataFitness.Models.FoodType", b =>
                {
                    b.Navigation("FoodDiets");
                });

            modelBuilder.Entity("API.DataFitness.Models.User", b =>
                {
                    b.Navigation("UserDieries");

                    b.Navigation("WorkoutPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
