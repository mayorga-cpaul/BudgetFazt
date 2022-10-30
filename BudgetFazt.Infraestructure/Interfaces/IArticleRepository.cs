using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Infraestructure.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<bool> SetArticle(Article article);
        Task<IEnumerable<Article>> GetAllArticles(int projectId);
    }
}
