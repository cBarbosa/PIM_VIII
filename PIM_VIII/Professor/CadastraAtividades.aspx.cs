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
    public partial class CadastraeAtividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Professor))
                    Response.Redirect("~/Default.aspx", true);

                PIM_VIII.VO.Professor professor = (PIM_VIII.VO.Professor)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);

                BindGridView(professor);
            }
        }

        private void BindGridView(PIM_VIII.VO.Professor professor)
        {
            try
            {
                try
                {
                    List<Cronograma> cronogramas = new CronogramaControl().GetAllCronogramaByProfessor(professor);
                    GridView1.DataSource = cronogramas;
                    GridView1.DataBind();

                    if (cronogramas == null)
                    {
                        msgRetorno.Text = "A pesquisa não retornou registros.";
                        msgRetorno.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                catch (Exception ex)
                {
                    msgRetorno.Text = ex.Message;
                    msgRetorno.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}