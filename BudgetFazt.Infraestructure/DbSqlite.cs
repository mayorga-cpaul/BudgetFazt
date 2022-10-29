namespace BudgetFazt.Infraestructure
{
    public static class DbSqlite
    {
        public static string GetConnection()
        {
            string? path = Directory.GetParent(path: Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "BudgetFazt.db");
            return $"Filename={path}";
        }
    }
}
