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
                sum += Math.Round(item.UnitPrice - (item.UnitPrice) * (item.Discount / 100), 2);

                budgetList.Add(new Budget 
                {
                    CódigoDeProducto = item.Id,
                    NombreDeArticulo = item.Name,
                    Description = item.Description,
                    Calidad = item.Quality,
                    Cantidad = item.Quantity,
                    PrecioUnitario = item.UnitPrice,
                    Descuento = item.Discount,
                    PrecioDespuésDeDescuento = Math.Round(item.UnitPrice - (item.UnitPrice)*(item.Discount/100), 2),
                    SumTotal = sum,
                });
            }

            return budgetList;
        }
    }
}
