using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using System.Web.Security;

namespace AntunIT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                string password = Crypto.SHA256(this.LoginForm.Password);

                con.Open();
                OleDbCommand query = new OleDbCommand("SELECT username, password FROM korisnici WHERE username=@ime AND password=@pass", con);
                query.Parameters.AddWithValue("@ime", this.LoginForm.UserName.ToString());
                query.Parameters.AddWithValue("@pass", password);
                OleDbDataReader data = query.ExecuteReader();

                while (data.Read())
                {
                    if (this.LoginForm.Password.Equals("AntunIT123"))
                    {
                        LoginForm.DestinationPageUrl = "ChangePassword.aspx";
                    }
                    else
                    {
                        LoginForm.DestinationPageUrl = "Index.aspx";
                    }

                    //FormsAuthentication.RedirectFromLoginPage();
                    FormsAuthentication.SetAuthCookie(data.GetString(0), LoginForm.RememberMeSet);
                    e.Authenticated = true;
                }
                data.Close();

            }
            catch (Exception ex)
            {
                this.LoginForm.FailureText = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}