using BudgetFazt.Infraestructure;
using BudgetFazt.Infraestructure.Data;
using BudgetWinForms.UI.Settings;
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
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            using (var db = new BudgetFaztContext())
            {
                await db.Database.EnsureCreatedAsync();
            }

            var services = new ServiceCollection();

            string connection = DbSqlite.GetConnection();

            if (connection.Equals(String.Empty))
            {
                return;
            }

            services.AddSqlite<BudgetFaztContext>(connection);

            SingletonForms.GetInstances(services);

            services.AddSingleton<FrmLogin>();

            ApplicationConfiguration.Initialize();

            using (var serivceScope = services.BuildServiceProvider())
            {
                ServicesReq.ServiceProvider = serivceScope;
                var main = serivceScope.GetRequiredService<FrmLogin>();
                Application.Run(main);
            }
        }
    }
}