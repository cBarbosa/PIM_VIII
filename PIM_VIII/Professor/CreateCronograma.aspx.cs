using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Professor
{
    public partial class CreateCronograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Professor))
                    Response.Redirect("~/Default.aspx", true);
                try
                {
                    PIM_VIII.VO.Professor professor = (PIM_VIII.VO.Professor)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

                    BindData(professor);
                }
                catch (Exception ex)
                {
                    msgRetorno.Text = ex.Message;
                    msgRetorno.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void BindData(PIM_VIII.VO.Professor professor)
        {
            try
            {
                dpCurso.DataSource = new CursoControl().GetAllCursos();
                dpCurso.DataTextField = "Nome";
                dpCurso.DataValueField = "ID";
                dpCurso.DataBind();

                dpDisciplina.DataSource = new DisciplinaControl()
                    .GetAllDisciplinasByIdCurso(professor.disciplina.curso.Id);
                dpDisciplina.DataTextField = "Nome";
                dpDisciplina.DataValueField = "ID";
                dpDisciplina.DataBind();

                dpAtividade.DataSource = new AtividadeControl().GetAllAtividadesProfessor();
                dpAtividade.DataTextField = "Nome";
                dpAtividade.DataValueField = "ID";
                dpAtividade.DataBind();

                dpDisciplina.SelectedValue = professor.disciplina.Id.ToString();
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
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

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strDt = txtDtInicio.Text.Split('/');
                DateTime dataInicio = new DateTime(int.Parse(strDt[2]), int.Parse(strDt[1]), int.Parse(strDt[0]));

                strDt = txtDtFim.Text.Split('/');
                DateTime dataFinal = new DateTime(int.Parse(strDt[2]), int.Parse(strDt[1]), int.Parse(strDt[0]));
                
                new CronogramaControl().InsereCronograma(int.Parse(dpAtividade.SelectedValue), int.Parse(dpDisciplina.SelectedValue), dataInicio, dataFinal);

                msgRetorno.Text = "Atividade inserida com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;

                btnEnviar.Visible = false;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
                throw ex;
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Professor/CadastraAtividades.aspx", true);
        }
    }
}