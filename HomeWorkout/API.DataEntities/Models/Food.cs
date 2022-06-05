using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class Food
    {
        public Food()
        {
            UserDiets = new HashSet<UserDiet>();
        }

        public string Name { get; set; }
        public string FoodTypeName { get; set; }
        public double Calories { get; set; }

        public virtual FoodType FoodTypeNameNavigation { get; set; }
        public virtual ICollection<UserDiet> UserDiets { get; set; }
    }
}
