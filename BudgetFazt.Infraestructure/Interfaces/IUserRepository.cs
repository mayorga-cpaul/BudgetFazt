using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Infraestructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> AccessToAppAsync(string email, string password);
        Task<int> LastCretedIndex();
        Task<User> GetByEmailPassword(string email, string password);
    }
}
