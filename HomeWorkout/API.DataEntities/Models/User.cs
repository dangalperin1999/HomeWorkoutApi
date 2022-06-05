using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class User
    {
        public User()
        {
            UserDieries = new HashSet<UserDiery>();
            UserDiets = new HashSet<UserDiet>();
            UserWorkoutPlans = new HashSet<UserWorkoutPlan>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FitnessGoal { get; set; }
        public string FitnessLevel { get; set; }
        public long Age { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<UserDiery> UserDieries { get; set; }
        public virtual ICollection<UserDiet> UserDiets { get; set; }
        public virtual ICollection<UserWorkoutPlan> UserWorkoutPlans { get; set; }
    }
}
