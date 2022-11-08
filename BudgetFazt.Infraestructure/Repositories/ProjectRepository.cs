using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using SmartSolution.Infraestructure.Data.Repositories;

namespace BudgetFazt.Infraestructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly BudgetFaztContext repository;
        public ProjectRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjects(int companyId)
        {
            return await Task.FromResult(repository.Projects.Where(e => e.CompanyId == companyId));
        }

        public Task<bool> SetCustomer(Customer article)
        {
            throw new NotImplementedException();
        }

        public async Task<int> LastCretedIndex()
        {
            return await repository.Projects.MaxAsync(e => e.Id);
        }
    }
}
