using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class UserWorkoutPlan
    {
        public long Id { get; set; }
        public long UsersId { get; set; }
        public string DayName { get; set; }
        public string ExerciseName { get; set; }
        public long Sets { get; set; }
        public long Reps { get; set; }

        public virtual Day DayNameNavigation { get; set; }
        public virtual Exercise ExerciseNameNavigation { get; set; }
        public virtual User Users { get; set; }
    }
}
