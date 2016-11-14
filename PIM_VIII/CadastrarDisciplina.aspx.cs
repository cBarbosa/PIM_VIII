using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PIM_VII.VO;
using PIM_VIII.Control;

namespace PIM_VIII
{
    public partial class CadastrarDisciplina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCurso.DataSource = PIM_VIII.Control.ctlcurso.GetAllDataSetCurso();
                ddlCurso.DataTextField = "Curso";
                ddlCurso.DataValueField = "ID_CURSO";
                ddlCurso.DataBind();

                ddlAtividade.DataSource = ctlAtividade.GetAllDataSetAtividade();
                ddlAtividade.DataTextField = "Atividade";
                ddlAtividade.DataValueField = "ID_ATIVIDADE";
                ddlAtividade.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                string nome = txtDisciplina.Text.ToUpper();
                int idCurso = int.Parse(ddlCurso.SelectedValue);
                int idAtividade = int.Parse(ddlAtividade.SelectedValue);

                Disciplina disciplina = new Disciplina();

                disciplina.Nome = nome;
                disciplina.IdCurso = idCurso;
                disciplina.IdAtividade = idAtividade;

                ctlDisciplina.InsertDisciplina(disciplina);
        }
    }
}