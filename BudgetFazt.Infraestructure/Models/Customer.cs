namespace BudgetFazt.Infraestructure.Models;

public partial class Customer
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Project Project { get; set; } = null!;
}
