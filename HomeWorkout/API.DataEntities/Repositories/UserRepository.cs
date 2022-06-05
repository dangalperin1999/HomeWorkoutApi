using API.DataFitness.Authenticators;
using API.DataFitness.Helpers;
using API.DataFitness.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(FitnessContext context ,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Update(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.Id);
            if(user.Password != null)
            {
                userToUpdate.Password = user.Password;
            }
            userToUpdate.FitnessGoal = user.FitnessGoal;
            userToUpdate.FitnessLevel = user.FitnessLevel;
            userToUpdate.Height = user.Height;
            userToUpdate.Weight = user.Weight;
            userToUpdate.Age = user.Age;
            userToUpdate.Gender = user.Gender;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
