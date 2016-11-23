using PIM_VII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Professor
{
    public partial class EditarCronograma : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = 0;
                int.TryParse(Request.QueryString["Id"], out id);

                if (id > 0)
                {
                    var cronograma = new CronogramaControl().getCronogramaById(id);
                    PreencheForm(cronograma);
                }
            }
        }

        private void PreencheForm(Cronograma cronograma)
        {
            dpCurso.DataSource = new AtendenteControl().GetAllCursos();
            dpCurso.DataTextField = "Nome";
            dpCurso.DataValueField = "ID";
            dpCurso.DataBind();

            dpDisciplina.DataSource = new DisciplinaControl()
                .GetAllDisciplinasByIdCurso(cronograma.disciplina.curso.Id);
            dpDisciplina.DataTextField = "Nome";
            dpDisciplina.DataValueField = "ID";
            dpDisciplina.DataBind();

            dpAtividade.DataSource = new AtividadeControl().GetAllAtividades();
            dpAtividade.DataTextField = "Nome";
            dpAtividade.DataValueField = "ID";
            dpAtividade.DataBind();

            dpCurso.SelectedValue = cronograma.disciplina.curso.Id.ToString();
            dpDisciplina.SelectedValue = cronograma.disciplina.Id.ToString();
            dpAtividade.SelectedValue = cronograma.atividade.Id.ToString();
            txtDtInicio.Text = cronograma.DataInicio.ToShortDateString();
            txtDtFim.Text = cronograma.DataFim.ToShortDateString();
        }

        protected void dpCurso_TextChanged(object sender, EventArgs e)
        {
            if (dpCurso.SelectedIndex != -1)
            {
                dpDisciplina.DataSource = new DisciplinaControl()
                    .GetAllDisciplinasByIdCurso(int.Parse(dpCurso.SelectedValue));
                dpDisciplina.DataTextField = "Nome";
                dpDisciplina.DataValueField = "ID";
                dpDisciplina.DataBind();
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Professor/CadastraAtividades.aspx", true);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strDt = txtDtInicio.Text.Split('/');
                DateTime dataInicio = new DateTime(int.Parse(strDt[2]), int.Parse(strDt[1]), int.Parse(strDt[0]));

                strDt = txtDtFim.Text.Split('/');
                DateTime dataFinal = new DateTime(int.Parse(strDt[2]), int.Parse(strDt[1]), int.Parse(strDt[0]));
                int.TryParse(Request.QueryString["Id"], out id);
                new CronogramaControl().UpdateCronograma(id, int.Parse(dpAtividade.SelectedValue), int.Parse(dpDisciplina.SelectedValue), dataInicio, dataFinal);

                msgRetorno.Text = "Alterações realizadas com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
                throw ex;
            }
            
        }
    }
}