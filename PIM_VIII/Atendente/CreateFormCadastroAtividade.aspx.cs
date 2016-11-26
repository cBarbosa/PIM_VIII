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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var atividade = new Atividade()
            {
                Nome = txtNome.Text
            };

            try
            {
                new AtividadeControl().InsereAtividade(atividade);
                msgRetorno.Text = "Cadastro realizado com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
                btnEnviar.Visible = false;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atendente/FormCadastraAtividade.aspx", true);
        }
    }
}