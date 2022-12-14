using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Infraestructure.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<bool> SetProject(Project article);
        Task<IEnumerable<Project>> GetAllProjects(int companyId);
        Task<int> LastCretedIndex();
        Task<IEnumerable<Company>> GetCompanies(int userId);
    }
}
