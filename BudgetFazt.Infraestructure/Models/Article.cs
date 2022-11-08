namespace BudgetFazt.Infraestructure.Models;

public partial class Article
{
    public int Id { get; set; }  // 4
    public int ProjectId { get; set; }// 4
    public string Name { get; set; } = String.Empty; // 100 * 2 = 200
    public double UnitPrice { get; set; } // 4
    public string Quality { get; set; } = string.Empty; // 100 * 2 = 200
    public int Quantity { get; set; } // 100 * 2 = 200
    public string Description { get; set; } = String.Empty; // 100 * 2 = 200
    public double Discount { get; set; } // 4
    public virtual Project Project { get; set; } = null!; 
}
