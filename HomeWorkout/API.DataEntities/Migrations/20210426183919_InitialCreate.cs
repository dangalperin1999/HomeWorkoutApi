using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.DataFitness.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "FitnessGoal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessGoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessLevel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    FoodTypeId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.FoodTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CategorisedExercises",
                columns: table => new
                {
                    CategoryExerciseId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FitnessGoalId = table.Column<long>(type: "INTEGER", nullable: false),
                    FitnessLevelId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExerciseId = table.Column<long>(type: "INTEGER", nullable: false),
                    Sets = table.Column<long>(type: "INTEGER", nullable: false),
                    Reps = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorisedExercises", x => x.CategoryExerciseId);
                    table.ForeignKey(
                        name: "FK_CategorisedExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategorisedExercises_FitnessGoal_FitnessGoalId",
                        column: x => x.FitnessGoalId,
                        principalTable: "FitnessGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategorisedExercises_FitnessLevel_FitnessLevelId",
                        column: x => x.FitnessLevelId,
                        principalTable: "FitnessLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'"),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'"),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<long>(type: "INTEGER", nullable: false),
                    Weight = table.Column<long>(type: "INTEGER", nullable: false),
                    FitnessGoalId = table.Column<long>(type: "INTEGER", nullable: false),
                    FitnessLevelId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_FitnessGoal_FitnessGoalId",
                        column: x => x.FitnessGoalId,
                        principalTable: "FitnessGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_FitnessLevel_FitnessLevelId",
                        column: x => x.FitnessLevelId,
                        principalTable: "FitnessLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FatPercent = table.Column<byte[]>(type: "NUMERIC", nullable: false),
                    Calories = table.Column<byte[]>(type: "NUMERIC", nullable: false),
                    FoodTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    FitnessGoalId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiet_FitnessGoal_FitnessGoalId",
                        column: x => x.FitnessGoalId,
                        principalTable: "FitnessGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodDiet_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "FoodTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsersId = table.Column<long>(type: "INTEGER", nullable: false),
                    CategoryExerciseId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlan_CategorisedExercises_CategoryExerciseId",
                        column: x => x.CategoryExerciseId,
                        principalTable: "CategorisedExercises",
                        principalColumn: "CategoryExerciseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutPlan_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDiery",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayId = table.Column<long>(type: "INTEGER", nullable: false),
                    FoodDietId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    FitnessGoalId = table.Column<long>(type: "INTEGER", nullable: true),
                    FitnessLevelId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDiery_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiery_FitnessGoal_FitnessGoalId",
                        column: x => x.FitnessGoalId,
                        principalTable: "FitnessGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiery_FitnessLevel_FitnessLevelId",
                        column: x => x.FitnessLevelId,
                        principalTable: "FitnessLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiery_FoodDiet_FoodDietId",
                        column: x => x.FoodDietId,
                        principalTable: "FoodDiet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiery_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorisedExercises_ExerciseId",
                table: "CategorisedExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorisedExercises_FitnessGoalId",
                table: "CategorisedExercises",
                column: "FitnessGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorisedExercises_FitnessLevelId",
                table: "CategorisedExercises",
                column: "FitnessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiet_FitnessGoalId",
                table: "FoodDiet",
                column: "FitnessGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiet_FoodTypeId",
                table: "FoodDiet",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiery_DayId",
                table: "UserDiery",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiery_FitnessGoalId",
                table: "UserDiery",
                column: "FitnessGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiery_FitnessLevelId",
                table: "UserDiery",
                column: "FitnessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiery_FoodDietId",
                table: "UserDiery",
                column: "FoodDietId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiery_UserId",
                table: "UserDiery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FitnessGoalId",
                table: "Users",
                column: "FitnessGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FitnessLevelId",
                table: "Users",
                column: "FitnessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlan_CategoryExerciseId",
                table: "WorkoutPlan",
                column: "CategoryExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlan_UsersId",
                table: "WorkoutPlan",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiery");

            migrationBuilder.DropTable(
                name: "WorkoutPlan");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "FoodDiet");

            migrationBuilder.DropTable(
                name: "CategorisedExercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "FitnessGoal");

            migrationBuilder.DropTable(
                name: "FitnessLevel");
        }
    }
}
