using BudgetFazt.Infraestructure.Models;

namespace BudgetFazt.Util.Processes
{
    public static class CalculusBudget
    {
        public static List<Budget> GetBudget(List<Article> budgets)
        {
            List<Budget> budgetList = new List<Budget>();
            double sum = 0;

            foreach (var item in budgets)
            {
                sum += Math.Round((item.UnitPrice - item.UnitPrice * item.Discount / 100)*item.Quantity, 2);

                budgetList.Add(new Budget 
                {
                    Id = item.Id,
                    ArticleName = item.Name,
                    Description = item.Description,
                    Quality = item.Quality,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount,
                    PriceAfterDiscount = Math.Round(item.UnitPrice - (item.UnitPrice)*(item.Discount/100), 2),
                    SumTotal = sum,
                });
            }

            return budgetList;
        }
    }
}
