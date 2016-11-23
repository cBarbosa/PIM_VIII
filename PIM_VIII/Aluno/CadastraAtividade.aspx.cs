
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Aluno
{
    public partial class CadastraAtividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                       .Equals(PerfilAcesso.Aluno))
                    Response.Redirect("~/Default.aspx", true);

                PIM_VII.VO.Aluno aluno = (PIM_VII.VO.Aluno)LoginControl.GetDadosAutenticados(Request.Cookies["ProjetoTCC"]);
                var cronograma = new CronogramaControl().GetAllAtividadesByAluno(aluno);

                GridView1.DataSource = cronograma;
                GridView1.DataBind();
               
            }
        }
    }
}