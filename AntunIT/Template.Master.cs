using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class Template : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.infoMessage.Visible = false;
            this.errorMessage.Visible = false;
            this.NameLbl.Text = getUser();

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            if(Session["info"]!=null)
            {
                this.infoMessage.Visible = true;
                this.InfoLabel.Text = (String)Session["info"];
                Session.Remove("info");
            }

            if (Session["error"] != null)
            {
                this.errorMessage.Visible = true;
                this.ErrorLabel.Text = (String)Session["error"];
                Session.Remove("error");
            }
        }

        protected void LogoutBttn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        private String getUser()
        {
            String query = "SELECT ime FROM korisnici WHERE username=@username";
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@username", HttpContext.Current.User.Identity.Name);

                OleDbDataReader data = cmd.ExecuteReader();

                while(data.Read())
                {
                    return data.GetString(0);
                }        
            }
            catch { }
            finally
            {
                con.Close();
            }

            return "Ja";
        }
    }
}