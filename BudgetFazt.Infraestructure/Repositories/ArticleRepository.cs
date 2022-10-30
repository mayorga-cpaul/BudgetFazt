using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using SmartSolution.Infraestructure.Data.Repositories;

namespace BudgetFazt.Infraestructure.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly BudgetFaztContext repository;
        public ArticleRepository(BudgetFaztContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Article>> GetAllArticles(int projectId)
        {
            return await Task.FromResult(repository.Articles.Where(e => e.ProjectId == projectId));
        }

        public Task<bool> SetArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
