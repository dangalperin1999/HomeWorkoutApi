using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class UserDiery
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ExerciseName { get; set; }
        public long Sets { get; set; }
        public long Reps { get; set; }

        public virtual Exercise ExerciseNameNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
