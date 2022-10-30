namespace BudgetFazt.Infraestructure.Models;

public partial class User
{
    public User()
    {
        Company = new HashSet<Company>();
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Company> Company { get; set; }
}
