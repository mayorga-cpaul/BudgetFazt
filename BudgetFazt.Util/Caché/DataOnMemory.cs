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
        public static bool State { get; set; }
    }

    public static class CustomerOnMemory
    {
        public static int Id { get; set; }
        public static int CompanyId { get; set; }
        public static string Name { get; set; } = String.Empty;

        public static string Phone { get; set; } = String.Empty;

        public static string Email { get; set; } = String.Empty;

        public static string Address { get; set; } = String.Empty;
    }
}
