﻿using PIM_VII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class CadastrarAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PIM_VIII.Control.LoginControl.GetPerfilUsuarioLogado(Request.Cookies["ProjetoTCC"])
                        .Equals(PerfilAcesso.Atendente))
                    Response.Redirect("~/Default.aspx", true);

                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                List<Aluno> alunos = new AtendenteControl().GetAllAlunos();
                GridView1.DataSource = alunos;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; // turn to edit mode
            BindGridView(); // Rebind GridView to show the data in edit mode
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; //swicth back to default mode
            BindGridView(); // Rebind GridView to show the data in default mode
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var splitStr = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0].FindControl("TextBox5")).Text.Split('/');
            var dataNasc = new DateTime(int.Parse(splitStr[2]), int.Parse(splitStr[1]), int.Parse(splitStr[0]));
            
            new AtendenteControl().AtualizarAluno(((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0].FindControl("TextBox1")).Text, ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("TextBox2")).Text, double.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("TextBox3")).Text), int.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0].FindControl("TextBox4")).Text), dataNasc, int.Parse(((DropDownList)GridView1.Rows[e.RowIndex].Cells[4].FindControl("drpCurso")).SelectedItem.Value.ToString()));

            GridView1.EditIndex = -1;
            BindGridView(); // Rebind GridView to reflect changes made
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;// get the id of the selected row 
            //DeleteRecord(id);//call delete method
            BindGridView();//rebind grid to reflect changes made
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}