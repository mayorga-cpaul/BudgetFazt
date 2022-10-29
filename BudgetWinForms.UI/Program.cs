using BudgetFazt.Infraestructure;
using BudgetFazt.Infraestructure.Data;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Repositories;
using BudgetWinForms.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetWinForms.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var services = new ServiceCollection();

            string connection = DbSqlite.GetConnection();

            if (connection.Equals(String.Empty))
            {
                return;
            }

            services.AddSqlite<BudgetFaztContext>(connection);

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();

            services.AddSingleton<FrmLogin>();

            ApplicationConfiguration.Initialize();

            using (var serivceScope = services.BuildServiceProvider())
            {
                var main = serivceScope.GetRequiredService<FrmLogin>();
                Application.Run(main);
            }
        }
    }
}