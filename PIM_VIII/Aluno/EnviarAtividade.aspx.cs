using PIM_VIII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Aluno
{
    public partial class EnviarAtividade : System.Web.UI.Page
    {
        Envio envio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Aluno))
                    Response.Redirect("~/Default.aspx", true);

                PIM_VIII.VO.Aluno aluno = (PIM_VIII.VO.Aluno)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

                int idCrono = 0;
                int.TryParse(Request.QueryString["Id"], out idCrono);

                PreencheForm(aluno);
            }
        }

        private void PreencheForm(PIM_VIII.VO.Aluno aluno)
        {
            int idCrono = 0;
            int.TryParse(Request.QueryString["Id"], out idCrono);
            envio = new EnvioControl().GetEnvioByIdCronogramaAluno(idCrono, aluno);

            if (envio == null)
                PreencherFormWithCronograma(aluno);
            else
            {
                lblCurso.Text = envio.cronograma.disciplina.curso.Nome;
                lblDisciplina.Text = envio.cronograma.disciplina.Nome;
                dtInicio.Text = envio.cronograma.DataInicio.ToShortDateString();
                dtFim.Text = envio.cronograma.DataFim.ToShortDateString();
                dtEnvio.Text = envio.DataEnvio.ToShortDateString();
                dtCorrecao.Text = envio.DataCorrecao.Equals(DateTime.MinValue) ? "N/D" : envio.DataCorrecao.ToShortDateString();
                txtNota.Text = envio.nota==-1 ? "N/D" : String.Format("{0:N}", envio.nota);
                txtObsProf.Text = String.IsNullOrEmpty(envio.ObsProfessor) ? "N/D" : envio.ObsProfessor;
                txtobs.Text = envio.ObsAluno;
                if(envio.nota>0)
                {
                    btnEnviar.Visible = false;
                    msgRetorno.Text = "Atividade já corrigida.";
                    msgRetorno.ForeColor = System.Drawing.Color.Gray;
                    FileUpload1.Visible = false;
                }
            }
        }

        private void PreencherFormWithCronograma(PIM_VIII.VO.Aluno aluno)
        {
            var crono = new CronogramaControl().getCronogramaById(aluno.CursoMatriculado.Id);
            lblCurso.Text = crono.disciplina.curso.Nome;
            lblDisciplina.Text = crono.disciplina.Nome;
            dtInicio.Text = crono.DataInicio.ToShortDateString();
            dtFim.Text = crono.DataFim.ToShortDateString();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            PIM_VIII.VO.Aluno aluno = (PIM_VIII.VO.Aluno)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

            int idCrono = 0;
            int.TryParse(Request.QueryString["Id"], out idCrono);

            try
            {
                new EnvioControl().EnviarAtividadeByAluno(idCrono, aluno, txtobs.Text, FileUpload1.HasFile ? FileUpload1.PostedFile : null);

                msgRetorno.Text = "Atividade salva com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
            PreencheForm(aluno);
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aluno/CadastraAtividade.aspx", true);
        }
    }
}