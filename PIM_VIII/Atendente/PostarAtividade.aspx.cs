using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class PostarAtividade : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["Id"], out id);

            if (!IsPostBack)
            {
                var cronograma = new CronogramaControl().getCronogramaById(id);
                if (cronograma == null)
                    return;

                lblCurso.Text = cronograma.disciplina.curso.Nome;
                lblDisciplina.Text = cronograma.disciplina.Nome;
                dtInicio.Text = cronograma.DataInicio.ToShortDateString();
                dtFim.Text = cronograma.DataFim.ToShortDateString();

                BindGridView();
            }
        }

        private void BindGridView()
        {
            dpAluno.DataSource = new AlunoControl().GetAllAlunos();
            dpAluno.DataTextField = "NOME";
            dpAluno.DataValueField = "MATRICULA";
            dpAluno.DataBind();
            dpAluno.Items.Insert(0, new ListItem("[Escolha o aluno]", "", true));
        }

        protected void dpAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["Id"], out id);

            var envio = new EnvioControl().GetEnvioByIdCronogramaMatriculaAluno(id, dpAluno.SelectedValue.ToString());

            if (envio != null)
            {
                msgRetorno.Text = String.Format("Atividade já enviada para este aluno em {0:dd/MM/yyyy}", envio.DataEnvio);
                msgRetorno.ForeColor = System.Drawing.Color.Red;
                pnPostagem.Visible = false;
                return;
            }
            pnPostagem.Visible = true;
            LinkButton1.Visible = false;
        }

        protected void dpAluno_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["Id"], out id);
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atendente/CadastraAtividade.aspx", true);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["Id"], out id);

            try
            {
                var aluno = new AlunoControl().GetAlunoByMatricula(dpAluno.SelectedValue);

                new EnvioControl().EnviarAtividadeByAluno(id, aluno, txtobs.Text, FileUpload1.HasFile ? FileUpload1.PostedFile : null);

                msgRetorno.Text = "Atividade salva com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
                btnEnviar.Visible = false;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}