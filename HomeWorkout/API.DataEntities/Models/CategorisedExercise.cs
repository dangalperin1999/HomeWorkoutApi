using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class CategorisedExercise
    {
        public long CategoryExerciseId { get; set; }
        public string DayName { get; set; }
        public string FitnessGoalName { get; set; }
        public string FitnessLevelName { get; set; }
        public string ExerciseName { get; set; }
        public long Sets { get; set; }
        public long Reps { get; set; }

        public virtual Day DayNameNavigation { get; set; }
        public virtual Exercise ExerciseNameNavigation { get; set; }
        public virtual FitnessGoal FitnessGoalNameNavigation { get; set; }
        public virtual FitnessLevel FitnessLevelNameNavigation { get; set; }
    }
}
