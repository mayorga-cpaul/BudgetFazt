using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using SmartSolution.Infraestructure.Data.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace BudgetFazt.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly BudgetFaztContext repository;
        public UserRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AccessToAppAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password)) return false;

            var result = await repository.Users.AnyAsync(e => e.Email.Equals(email) && e.Password.Equals(password));
            return result;
        }

        public async Task<User> GetByEmailPassword(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password)) throw new Exception("Los campos están vacios");
            var result = await repository.Users.FirstOrDefaultAsync(e => e.Email.Equals(email) && e.Password.Equals(password));

            if (result is null)
            {
                throw new Exception("El usuario no existe");
            }

            return result;
        }

        public async Task<int> LastCretedIndex()
        {
            return await repository.Users.MaxAsync(e => e.Id);
        }
    }
}
