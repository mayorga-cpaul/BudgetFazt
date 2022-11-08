using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using SmartSolution.Infraestructure.Data.Repositories;

namespace BudgetFazt.Infraestructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {

        // Metodo importantes de nuestro objeto que hace referencia 
        // Company 
        private readonly BudgetFaztContext repository;
        public CompanyRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjects(int companyId)
        {
            return await Task.FromResult(repository.Projects.Where(e => e.CompanyId == companyId));
        }

        public async Task<IEnumerable<Company>> GetCompanies(int userId)
        {
            return await Task.FromResult(repository.Companies.Where(e => e.UserId == userId));
        }

        public async Task<int> LastCretedIndex()
        {
            return await repository.Users.MaxAsync(e => e.Id);
        }

        public Task<bool> SetProject(Project article)
        {
            throw new NotImplementedException();
        }
    }
}
