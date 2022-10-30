using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Infraestructure.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<bool> SetProject(Project article);
        Task<IEnumerable<Project>> GetAllArticles(int companyId);
    }
}
