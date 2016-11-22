using PIM_VII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Professor
{
    public partial class EditarCronograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                int.TryParse(Request.QueryString["Id"], out id);

                if (id > 0)
                {
                    var cronograma = new CronogramaControl().getCronogramaById(id);
                    PreencheForm(cronograma);
                }
            }
        }

        private void PreencheForm(Cronograma cronograma)
        {
            dpCurso.DataSource = new AtendenteControl().GetAllCursos();
            dpCurso.DataTextField = "Nome";
            dpCurso.DataValueField = "ID";
            dpCurso.DataBind();

            dpDisciplina.DataSource = new DisciplinaControl().GetAllDisciplinasByIdCurso(cronograma.disciplina.curso.Id);
            dpDisciplina.DataTextField = "Nome";
            dpDisciplina.DataValueField = "ID";
            dpDisciplina.DataBind();

            dpAtividade.DataSource = new AtividadeControl().GetAllAtividades();
            dpAtividade.DataTextField = "Nome";
            dpAtividade.DataValueField = "ID";
            dpAtividade.DataBind();

            dpCurso.SelectedValue = cronograma.disciplina.curso.Id.ToString();
            dpAtividade.SelectedValue = cronograma.atividade.Id.ToString();
            txtDtInicio.Text = cronograma.DataInicio.ToShortDateString();
            txtDtFim.Text = cronograma.DataFim.ToShortDateString();
        }
    }
}