using System;
using System.Collections.Generic;

namespace BudgetFazt.Infraestructure.Models;

public partial class Company
{
    public Company()
    {
        Project = new HashSet<Project>();
        Customer = new HashSet<Customer>();
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? CompanyName { get; set; }

    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty; 
    public virtual User User { get; set; } = null!;
    public virtual ICollection<Customer> Customer { get; set; }

    public virtual ICollection<Project> Project { get; set; }
}
