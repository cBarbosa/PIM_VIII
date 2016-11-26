﻿using PIM_VIII.VO;
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
                dpCurso.DataSource = new CursoControl().GetAllCursos();
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
            try
            {
                new AlunoControl().InsereAluno(txtNome.Text, txtMatricula.Text, double.Parse(txtCPF.Text), int.Parse(txtRG.Text), Utils.GetDateByStrDate(txtDataNascimento.Text), int.Parse(dpCurso.SelectedValue));
                msgRetorno.Text = "Aluno Cadastrado com sucesso e senha gerada.";
                msgRetorno.ForeColor = System.Drawing.Color.Green;
                btnEnviar.Enabled = false;
            }
            catch (Exception ex)
            {
                msgRetorno.Text = ex.Message;
                msgRetorno.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}