using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Authenticators
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FitnessGoal { get; set; }
        public string FitnessLevel { get; set; }
        public long Age { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public string Gender { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            FitnessGoal = user.FitnessGoal;
            FitnessLevel = user.FitnessLevel;
            Age = user.Age;
            Height = user.Height;
            Weight = user.Weight;
            Gender = user.Gender;
            Token = token;
        }
    }
}
