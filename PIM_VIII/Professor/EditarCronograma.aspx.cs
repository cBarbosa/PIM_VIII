using PIM_VIII.VO;
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

                try
                {
                    if (id > 0)
                    {
                        var cronograma = new CronogramaControl().getCronogramaById(id);
                        PreencheForm(cronograma);
                    }
                }
                catch (Exception ex)
                {
                    msgRetorno.Text = ex.Message;
                    msgRetorno.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void PreencheForm(Cronograma cronograma)
        {
            dpCurso.DataSource = new CursoControl().GetAllCursos();
            dpCurso.DataTextField = "Nome";
            dpCurso.DataValueField = "ID";
            dpCurso.DataBind();

            dpDisciplina.DataSource = new DisciplinaControl()
                .GetAllDisciplinasByIdCurso(cronograma.disciplina.curso.Id);
            dpDisciplina.DataTextField = "Nome";
            dpDisciplina.DataValueField = "ID";
            dpDisciplina.DataBind();

            dpAtividade.DataSource = new AtividadeControl().GetAllAtividadesProfessor();
            dpAtividade.DataTextField = "Nome";
            dpAtividade.DataValueField = "ID";
            dpAtividade.DataBind();

            dpCurso.SelectedValue = cronograma.disciplina.curso.Id.ToString();
            dpDisciplina.SelectedValue = cronograma.disciplina.Id.ToString();
            dpAtividade.SelectedValue = cronograma.atividade.Id.ToString();
            txtDtInicio.Text = cronograma.DataInicio.ToString("yyyy-MM-dd");
            txtDtFim.Text = cronograma.DataFim.ToString("yyyy-MM-dd");
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
                int.TryParse(Request.QueryString["Id"], out id);
                new CronogramaControl().UpdateCronograma(id, int.Parse(dpAtividade.SelectedValue), int.Parse(dpDisciplina.SelectedValue), Utils.GetDateByStrDate(txtDtInicio.Text), Utils.GetDateByStrDate(txtDtFim.Text));

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