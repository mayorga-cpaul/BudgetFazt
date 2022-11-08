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
        // Se hace con inyección de depencias esto
        private readonly BudgetFaztContext repository;
        public UserRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        // Metodo que te permite acceder a la base de datos
        public async Task<bool> AccessToAppAsync(string email, string password)
        {
            // Verifica que los datos sean validos y no esten vacios    
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password)) return false;

            // Lo hicimos con lambda Expressions
            var result = await repository.Users.AnyAsync(e => e.Email.Equals(email) && e.Password.Equals(password));
            return result;
        }

        public async Task<bool> ExistName(string email)
        {
            // Verifica que vayan datos correctos a la db por ejemplo email únicos que no se repitan
            return await repository.Users.AnyAsync(e => e.Email.Equals(email));
        }

        public async Task<bool> ExistOnDb(string email)
        {
            // Verifica que vayan datos correctos a la db por ejemplo email únicos que no se repitan
            return await repository.Users.AnyAsync(e => e.Email.Equals(email));
        }

        public async Task<User> GetByEmailPassword(string email, string password)
        {
            // valida que los campos no esten vacios
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password)) throw new Exception("Los campos están vacios");
            var result = await repository.Users.FirstOrDefaultAsync(e => e.Email.Equals(email) && e.Password.Equals(password));

            // Mensaje de error
            if (result is null)
            {
                throw new Exception("El usuario no existe");
            }

            return result;
        }

        public async Task<int> LastCretedIndex()
        {
            // Obtiene el ultimo registro osea su Id
            return await repository.Users.MaxAsync(e => e.Id);
        }
    }
}
