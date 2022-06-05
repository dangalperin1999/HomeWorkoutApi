using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class FitnessGoal
    {
        public FitnessGoal()
        {
            CategorisedExercises = new HashSet<CategorisedExercise>();
        }

        public string Name { get; set; }

        public virtual ICollection<CategorisedExercise> CategorisedExercises { get; set; }
    }
}
