using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Article
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public double UnitPrice { get; set; }

    public long Quantity { get; set; }

    public string? Description { get; set; }

    public double Discount { get; set; }

    public virtual Project IdNavigation { get; set; } = null!;
}
