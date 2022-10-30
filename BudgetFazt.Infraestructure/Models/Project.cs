using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Project
{
    public Project()
    {
        Article = new HashSet<Article>();
    }
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string NameProject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<Article> Article { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Company Company { get; set; } = null!;
}
