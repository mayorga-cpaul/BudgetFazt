using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Company
{
    public Company()
    {
        Project = new HashSet<Project>();
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? CompanyName { get; set; }

    public string? Description { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Project> Project { get; set; }
}
