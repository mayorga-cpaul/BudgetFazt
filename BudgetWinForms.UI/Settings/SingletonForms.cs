using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Repositories;
using BudgetWinForms.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetWinForms.UI.Settings
{
    public static class SingletonForms
    {
        public static Form GetForm(FormType type)
        {
            switch (type)
            {
                case FormType.FrmAddCompany:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmAddCompany>();
                case FormType.FrmAddCustomer:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmAddCustomer>();
                case FormType.FrmAddProject:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmAddProject>();
                case FormType.FrmArticle:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmArticle>();
                case FormType.FrmBudget:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmBudget>();
                case FormType.FrmCompanies:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmCompanies>();
                case FormType.FrmLogin:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmLogin>();
                case FormType.FrmMain:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmMain>();
                case FormType.FrmRegister:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmRegister>();
                case FormType.FrmStart:
                    return ServicesReq.ServiceProvider.GetRequiredService<FrmStart>();
                default: return null!;
            }
        }


        public static void GetInstances(this ServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddSingleton<FrmAddCompany>();
            services.AddSingleton<FrmAddCustomer>();
            services.AddSingleton<FrmAddProject>();
            services.AddSingleton<FrmArticle>();
            services.AddSingleton<FrmBudget>();
            services.AddSingleton<FrmCompanies>();
            services.AddSingleton<FrmMain>();
            services.AddSingleton<FrmRegister>();
            services.AddSingleton<FrmStart>();
        }
    }
}