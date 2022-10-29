using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Project
{
    public long Id { get; set; }

    public string NameProject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public virtual Article? Article { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Company IdNavigation { get; set; } = null!;
}
