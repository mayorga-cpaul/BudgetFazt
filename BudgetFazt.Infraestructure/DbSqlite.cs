using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace BudgetFazt.Infraestructure
{
    public static class DbSqlite
    {
        public static string GetConnection()
        {
            string? path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            return $"Filename={path}\\BudgetFazt.db";
        }
    }
}
