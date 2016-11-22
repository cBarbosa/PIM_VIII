using PIM_VII.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM_VIII.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }



        protected void login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Pessoa usuario;
            try
            {
                usuario = new PIM_VIII.Control.LoginControl().ValidaLogin(login1.UserName, login1.Password);
            }
            catch (Exception ex)
            {
                login1.FailureText = ex.Message;
                return;
            }

            if (usuario != null)
            {
                if (Request.QueryString["ReturnUrl"] != null)
                    FormsAuthentication.RedirectFromLoginPage(usuario.Nome, login1.RememberMeSet);
                else
                    Response.Redirect("~/About.aspx", true);
            }
            else
            {
                login1.FailureText = "Dados para login incorretos.";
            }
        }
    }
}