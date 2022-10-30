using System.Data;

namespace BudgetFazt.Util.Caché
{
    public static class DataOnMemory
    {
        public static int UserId { get; set; }
        public static int ProjectId { get; set; }
        public static int CustomerId { get; set; }
        public static int ArticleId { get; set; }
        public static int CompanyId { get; set; }
        public static string UserName { get; set; } = String.Empty;
    }
}
