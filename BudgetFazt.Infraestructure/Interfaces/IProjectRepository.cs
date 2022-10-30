using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Infraestructure.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<bool> SetCustomer(Customer article);
        Task<IEnumerable<Project>> GetAllProjects(int companyId);
        Task<int> LastCretedIndex();
    }
}
