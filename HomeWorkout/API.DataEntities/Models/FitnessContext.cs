using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class FitnessContext : DbContext
    {
        public FitnessContext()
        {
        }

        public FitnessContext(DbContextOptions<FitnessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategorisedExercise> CategorisedExercises { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<FitnessGoal> FitnessGoals { get; set; }
        public virtual DbSet<FitnessLevel> FitnessLevels { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDiery> UserDieries { get; set; }
        public virtual DbSet<UserDiet> UserDiets { get; set; }
        public virtual DbSet<UserWorkoutPlan> UserWorkoutPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\Source\\Repos\\HomeWorkout\\HomeWorkout\\API.DataEntities\\Data\\fitness.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorisedExercise>(entity =>
            {
                entity.HasKey(e => e.CategoryExerciseId);

                entity.HasIndex(e => e.CategoryExerciseId, "IX_CategorisedExercises_CategoryExerciseId")
                    .IsUnique();

                entity.Property(e => e.DayName).IsRequired();

                entity.Property(e => e.ExerciseName).IsRequired();

                entity.Property(e => e.FitnessGoalName).IsRequired();

                entity.Property(e => e.FitnessLevelName).IsRequired();

                entity.HasOne(d => d.DayNameNavigation)
                    .WithMany(p => p.CategorisedExercises)
                    .HasForeignKey(d => d.DayName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ExerciseNameNavigation)
                    .WithMany(p => p.CategorisedExercises)
                    .HasForeignKey(d => d.ExerciseName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FitnessGoalNameNavigation)
                    .WithMany(p => p.CategorisedExercises)
                    .HasForeignKey(d => d.FitnessGoalName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FitnessLevelNameNavigation)
                    .WithMany(p => p.CategorisedExercises)
                    .HasForeignKey(d => d.FitnessLevelName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.HasKey(e => e.Name);
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.Name);
            });

            modelBuilder.Entity<FitnessGoal>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("FitnessGoal");
            });

            modelBuilder.Entity<FitnessLevel>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("FitnessLevel");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Food");

                entity.Property(e => e.FoodTypeName).IsRequired();

                entity.HasOne(d => d.FoodTypeNameNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodTypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.HasKey(e => e.Name);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Users_Id")
                    .IsUnique();

                entity.Property(e => e.FitnessGoal).IsRequired();

                entity.Property(e => e.FitnessLevel).IsRequired();

                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<UserDiery>(entity =>
            {
                entity.ToTable("UserDiery");

                entity.HasIndex(e => e.Id, "IX_UserDiery_Id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_UserDiery_UserId");

                entity.Property(e => e.ExerciseName).IsRequired();

                entity.HasOne(d => d.ExerciseNameNavigation)
                    .WithMany(p => p.UserDieries)
                    .HasForeignKey(d => d.ExerciseName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDieries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserDiet>(entity =>
            {
                entity.ToTable("UserDiet");

                entity.HasIndex(e => e.Id, "IX_UserDiet_Id")
                    .IsUnique();

                entity.Property(e => e.DayName).IsRequired();

                entity.Property(e => e.FoodName).IsRequired();

                entity.Property(e => e.FoodTypeName).IsRequired();

                entity.HasOne(d => d.DayNameNavigation)
                    .WithMany(p => p.UserDiets)
                    .HasForeignKey(d => d.DayName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.UserDiets)
                    .HasForeignKey(d => d.FoodName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FoodTypeNameNavigation)
                    .WithMany(p => p.UserDiets)
                    .HasForeignKey(d => d.FoodTypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDiets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserWorkoutPlan>(entity =>
            {
                entity.ToTable("UserWorkoutPlan");

                entity.HasIndex(e => e.Id, "IX_UserWorkoutPlan_Id")
                    .IsUnique();

                entity.HasIndex(e => e.UsersId, "IX_WorkoutPlan_UsersId");

                entity.Property(e => e.DayName).IsRequired();

                entity.Property(e => e.ExerciseName).IsRequired();

                entity.HasOne(d => d.DayNameNavigation)
                    .WithMany(p => p.UserWorkoutPlans)
                    .HasForeignKey(d => d.DayName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ExerciseNameNavigation)
                    .WithMany(p => p.UserWorkoutPlans)
                    .HasForeignKey(d => d.ExerciseName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UserWorkoutPlans)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
