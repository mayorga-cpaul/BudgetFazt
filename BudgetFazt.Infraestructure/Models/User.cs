using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class User
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual Company? Company { get; set; }
}
