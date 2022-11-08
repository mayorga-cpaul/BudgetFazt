namespace BudgetFazt.Infraestructure.Models;

public partial class Project
{
    // Constructor que inicializa una lista HatSet articulos 
    // articulos que pertenecen a un proyecto
    // Relación de uno a muchos
    
    public Project()
    {
        Article = new HashSet<Article>();
    }

    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string NameProject { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual ICollection<Article> Article { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Company Company { get; set; } = null!;
}