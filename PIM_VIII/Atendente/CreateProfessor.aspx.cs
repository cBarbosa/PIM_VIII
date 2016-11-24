using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class CreateProfessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpDisciplina.DataSource = new DisciplinaControl().GetAllDisciplinas();
                dpDisciplina.DataTextField = "Nome";
                dpDisciplina.DataValueField = "ID";
                dpDisciplina.DataBind();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] dts;
            if (String.IsNullOrEmpty(txtDataNascimento.Text))
                dts = new string[] { "1", "1", "1900" };
            else
                dts = txtDataNascimento.Text.Split('/');
            try
            {
                new ProfessorControl().InsereProfessor(txtNome.Text, txtMatricula.Text, double.Parse(txtCPF.Text), int.Parse(txtRG.Text), new DateTime(int.Parse(dts[2]), int.Parse(dts[1]), int.Parse(dts[0])), int.Parse(dpDisciplina.SelectedValue));
                msgRetorno.Text = "Professor cadastrado com sucesso.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atendente/CadastrarProfessor.aspx", true);
        }
    }
}