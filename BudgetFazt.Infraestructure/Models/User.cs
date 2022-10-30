namespace BudgetFazt.Infraestructure.Models;

public partial class User
{
    public User()
    {
        Company = new HashSet<Company>();
    }
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public virtual ICollection<Company> Company { get; set; }
}
