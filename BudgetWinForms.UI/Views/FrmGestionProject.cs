using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetFazt.Util.Processes;
using ReaLTaiizor.Controls;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmGestionProject : Form
    {
        IProjectRepository projectRepository;
        public FrmGestionProject(IProjectRepository projectRepository)
        {
            InitializeComponent();
            this.projectRepository = projectRepository;
        }

        private async void FrmGestionProject_Load(object sender, EventArgs e)
        {
            await Charge();
        }

        private async Task Charge()
        {
            dtgProjects.DataSource = (from s in (await projectRepository.GetAllProjects(DataOnMemory.CompanyId)) select new { s.Id, s.NameProject, s.Description, s.StartDate, s.EndDate, s.State }).ToList();
            dtgProjects.Columns[0].Visible = false;

            dtgProjects.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgProjects.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgProjects.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgProjects.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgProjects.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void btnEnableProject_Click(object sender, EventArgs e)
        {
            int id = 0;
            if ((int)dtgProjects.Rows.Count > 0)
                id = id = (int)dtgProjects.Rows[dtgProjects.CurrentRow.Index].Cells[0].Value;
            else
                return;

            if (id == 0)
            {
                return;
            }
            var project = await projectRepository.GetAsync(id);
            project.State = "Habilitado";
            await projectRepository.UpdateAsync(project);
            await Charge();
        }

        private async void btnDisableProject_Click(object sender, EventArgs e)
        {
            int id = 0;
            if ((int)dtgProjects.Rows.Count > 0)
                id = id = (int)dtgProjects.Rows[dtgProjects.CurrentRow.Index].Cells[0].Value;
            else
                return;

            if (id == 0)
            {
                return;
            }

            var project = await projectRepository.GetAsync(id);
            project.State = "Inhabilitado";
            await projectRepository.UpdateAsync(project);
            await Charge();
        }
    }
}
