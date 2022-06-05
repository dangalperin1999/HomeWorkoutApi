using System;
using System.Collections.Generic;

#nullable disable

namespace API.DataFitness.Models
{
    public partial class UserDiet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DayName { get; set; }
        public string FoodName { get; set; }
        public string FoodTypeName { get; set; }
        public double Grams { get; set; }
        public double Calories { get; set; }

        public virtual Day DayNameNavigation { get; set; }
        public virtual Food FoodNameNavigation { get; set; }
        public virtual FoodType FoodTypeNameNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
