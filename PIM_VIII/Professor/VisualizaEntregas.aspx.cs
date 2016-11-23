using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Professor
{
    public partial class VisualizaEntregas : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Professor))
                    Response.Redirect("~/Default.aspx", true);

                id = 0;
                int.TryParse(Request.QueryString["Id"], out id);

                PIM_VII.VO.Professor professor = (PIM_VII.VO.Professor)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);
                var envios = new EnvioControl().GetAllEnviosByProfessor(professor);

                GridView1.DataSource = envios;
                GridView1.DataBind();
            }
        }
    }
}