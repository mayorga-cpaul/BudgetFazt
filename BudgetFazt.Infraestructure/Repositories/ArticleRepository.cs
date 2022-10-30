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

        public Task<IEnumerable<Article>> GetAllArticles(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
