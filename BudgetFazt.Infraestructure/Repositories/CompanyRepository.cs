using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using SmartSolution.Infraestructure.Data.Repositories;

namespace BudgetFazt.Infraestructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly BudgetFaztContext repository;
        public CompanyRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Project>> GetAllArticles(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetProject(Project article)
        {
            throw new NotImplementedException();
        }
    }
}
