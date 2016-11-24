using PIM_VIII.VO;
using PIM_VIII.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Atendente
{
    public partial class CadastraAtividade : System.Web.UI.Page
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
            try
            {
                List<Cronograma> cronogramas = new CronogramaControl().GetAllCronogramas();
                GridView1.DataSource = cronogramas;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}