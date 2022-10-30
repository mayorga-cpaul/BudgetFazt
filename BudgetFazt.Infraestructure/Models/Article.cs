using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Article
{
    public int Id { get; set; }
    public int ProjectId { get; set; }

    public string? Name { get; set; }

    public double UnitPrice { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public double Discount { get; set; }

    public virtual Project Project { get; set; } = null!;
}
