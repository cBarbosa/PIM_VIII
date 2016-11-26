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
    public partial class FormCadastraAtividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            GridView1.DataSource = new AtividadeControl().GetAllAtividades();
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string txtAtividade = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("TextBox1")).Text;
            int idAtividade = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text.ToString());
            var atividade = new Atividade()
            {
                Id = idAtividade,
                Nome = txtAtividade
            };
            new AtividadeControl().AtualizaAtividade(atividade);

            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(e.Values[0].ToString());
            new AtividadeControl().ExcluirAtividadeById(id);
            BindGridView();
        }
    }
}