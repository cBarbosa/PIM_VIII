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
    public partial class AvaliaAtividade : System.Web.UI.Page
    {
        Envio envio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                           .Equals(PerfilAcesso.Professor))
                    Response.Redirect("~/Default.aspx", true);

                PIM_VII.VO.Professor professor = (PIM_VII.VO.Professor)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

                int idCrono = 0;
                int.TryParse(Request.QueryString["Id"], out idCrono);

                PreencheForm(professor);
            }
        }

        private void PreencheForm(PIM_VII.VO.Professor professor)
        {
            try
            {
                int idCrono = 0;
                int.TryParse(Request.QueryString["Id"], out idCrono);

                envio = new EnvioControl().GetEnvioByIdCronogramaProfessor(idCrono, professor);

                    lblCurso.Text = envio.cronograma.disciplina.curso.Nome;
                    lblDisciplina.Text = envio.cronograma.disciplina.Nome;
                    dtInicio.Text = envio.cronograma.DataInicio.ToShortDateString();
                    dtFim.Text = envio.cronograma.DataFim.ToShortDateString();
                    dtEnvio.Text = envio.DataEnvio.ToShortDateString();
                    dtCorrecao.Text = envio.DataCorrecao.Equals(DateTime.MinValue) ? "N/D" : envio.DataCorrecao.ToShortDateString();
                    txtNota.Text = envio.nota == -1 ? String.Empty : envio.nota.ToString();
                    txtobs.Text = String.IsNullOrEmpty(envio.ObsProfessor) ? "" : envio.ObsProfessor;
                    txtobs.Text = envio.ObsAluno;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int nota = 0;
            int.TryParse(txtNota.Text, out nota);

            PIM_VII.VO.Professor professor = (PIM_VII.VO.Professor)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

            int idEnvio = 0;
            int.TryParse(Request.QueryString["Id"], out idEnvio);

            try
            {
                new EnvioControl().EnviarAtividadeByProfessor(idEnvio, professor, nota, txtObsProf.Text);

                msgRetorno.Text = "Atividade corrigida com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
            PreencheForm(professor);
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Professor/CadastraAtividades.aspx", true);
        }
    }
}