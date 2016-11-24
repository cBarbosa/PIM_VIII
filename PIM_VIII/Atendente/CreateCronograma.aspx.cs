using PIM_VIII.Control;
using PIM_VIII.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class CreateCronograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Atendente))
                    Response.Redirect("~/Default.aspx", true);
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {
                    msgRetorno.Text = ex.Message;
                    msgRetorno.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void BindData()
        {
            try
            {
                dpCurso.DataSource = new CursoControl().GetAllCursos();
                dpCurso.DataTextField = "Nome";
                dpCurso.DataValueField = "ID";
                dpCurso.DataBind();

                dpDisciplina.DataSource = new DisciplinaControl()
                    .GetAllDisciplinasByIdCurso(int.Parse(dpCurso.SelectedValue));
                dpDisciplina.DataTextField = "Nome";
                dpDisciplina.DataValueField = "ID";
                dpDisciplina.DataBind();

                dpAtividade.DataSource = new AtividadeControl().GetAllAtividadesAtendente();
                dpAtividade.DataTextField = "Nome";
                dpAtividade.DataValueField = "ID";
                dpAtividade.DataBind();
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
                string[] strDt = txtDtInicio.Text.Split('-');
                DateTime dataInicio = new DateTime(int.Parse(strDt[0]), int.Parse(strDt[1]), int.Parse(strDt[2]));

                strDt = txtDtFim.Text.Split('-');
                DateTime dataFinal = new DateTime(int.Parse(strDt[0]), int.Parse(strDt[1]), int.Parse(strDt[2]));

                new CronogramaControl().InsereCronograma(int.Parse(dpAtividade.SelectedValue), int.Parse(dpDisciplina.SelectedValue), dataInicio, dataFinal);

                msgRetorno.Text = "Atividade inserida com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;

                btnEnviar.Visible = false;

                dpCurso.Enabled = false;
                dpAtividade.Enabled = false;
                dpDisciplina.Enabled = false;
                txtDtInicio.Enabled = false;
                txtDtFim.Enabled = false;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atendente/CadastraAtividade.aspx", true);
        }
    }
}