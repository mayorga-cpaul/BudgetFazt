using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Company
{
    public long Id { get; set; }

    public string? CompanyName { get; set; }

    public string? Description { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual Project? Project { get; set; }
}
