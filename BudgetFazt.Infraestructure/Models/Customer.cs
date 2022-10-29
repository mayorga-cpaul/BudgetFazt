using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Project IdNavigation { get; set; } = null!;
}
