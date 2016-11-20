using PIM_VII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class CreateAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpCurso.DataSource = new AtendenteControl().GetAllCursos();
                dpCurso.DataTextField = "Nome";
                dpCurso.DataValueField = "ID";
                dpCurso.DataBind();
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atendente/CadastrarAluno.aspx", true);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] dts;
            if (String.IsNullOrEmpty(txtDataNascimento.Text))
                dts = new string[] { "1","1","1900"};
            else
                dts = txtDataNascimento.Text.Split('/');
            try
            {
                new AtendenteControl().InsereAluno(txtNome.Text, txtMatricula.Text, int.Parse(txtCPF.Text), int.Parse(txtRG.Text), new DateTime(int.Parse(dts[2]), int.Parse(dts[1]), int.Parse(dts[0])), int.Parse(dpCurso.SelectedValue));
                Response.Redirect("~/Atendente/CadastrarAluno.aspx", true);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}