using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class Day
    {
        public Day()
        {
            CategorisedExercises = new HashSet<CategorisedExercise>();
            UserDiets = new HashSet<UserDiet>();
            UserWorkoutPlans = new HashSet<UserWorkoutPlan>();
        }

        public string Name { get; set; }

        public virtual ICollection<CategorisedExercise> CategorisedExercises { get; set; }
        public virtual ICollection<UserDiet> UserDiets { get; set; }
        public virtual ICollection<UserWorkoutPlan> UserWorkoutPlans { get; set; }
    }
}
