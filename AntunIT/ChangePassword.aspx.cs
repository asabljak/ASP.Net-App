using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        String username;
        String oldPassword;
        String password;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePasswordBttn_Click(object sender, EventArgs e)
        {
            username = HttpContext.Current.User.Identity.Name.ToString();
            oldPassword = this.OldUserPassTb.Text.ToString();
            password = Crypto.SHA256(this.NewUserPassTb.Text.ToString());

            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();
                if (!this.oldPassword.Equals(this.NewUserPassTb.Text))
                {
                    if (this.NewUserPassTb.Text.Equals(this.RepeatPassTb.Text.ToString()) && this.NewUserPassTb.Text != "" && UserOk(con))
                    {
                        String sql = "UPDATE [korisnici] SET [password] = @pass WHERE [username] = @user";
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@user", username);

                        cmd.ExecuteNonQuery();

                        Session.Add("info", "Lozinka uspješno promjenjena!");
                        Response.Redirect("Index.aspx", false);
                    }
                    else
                    {
                        
                        ErrorMessage("Uneseni podaci se ne podudaraju. Molim pokušajte ponovno");
                    } 
                }
                else
                {
                    ErrorMessage("Nova i stara lozinka ne smiju biti iste");
                }

            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private bool UserOk(OleDbConnection con)
        {
            OleDbCommand query = new OleDbCommand("SELECT username, password FROM Korisnici WHERE username=@ime AND password=@pass", con);
            query.Parameters.AddWithValue("@ime", HttpContext.Current.User.Identity.Name.ToString());
            query.Parameters.AddWithValue("@pass", Crypto.SHA256(oldPassword));
            OleDbDataReader data = query.ExecuteReader();

            while (data.Read())
            {
                return true;
            }

            return false;
        }

        private void ErrorMessage(String text)
        {
            Panel Panel;
            Label ErrorLabel;

            Panel = (Panel)Master.FindControl("errorMessage");
            ErrorLabel = (Label)this.Master.FindControl("ErrorLabel");

            Panel.Visible = true;
            ErrorLabel.Text = text;
        }

    }
}