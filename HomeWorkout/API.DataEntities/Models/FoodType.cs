using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class FoodType
    {
        public FoodType()
        {
            Foods = new HashSet<Food>();
            UserDiets = new HashSet<UserDiet>();
        }

        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<UserDiet> UserDiets { get; set; }
    }
}
