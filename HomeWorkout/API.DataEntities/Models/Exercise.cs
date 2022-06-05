using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            CategorisedExercises = new HashSet<CategorisedExercise>();
            UserDieries = new HashSet<UserDiery>();
            UserWorkoutPlans = new HashSet<UserWorkoutPlan>();
        }

        public string Name { get; set; }

        public virtual ICollection<CategorisedExercise> CategorisedExercises { get; set; }
        public virtual ICollection<UserDiery> UserDieries { get; set; }
        public virtual ICollection<UserWorkoutPlan> UserWorkoutPlans { get; set; }
    }
}
