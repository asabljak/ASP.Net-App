using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace AntunIT
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = DatabaseHelper.getUser(HttpContext.Current.User.Identity.Name);

            this.Update_UsernameLbl.Text = user.Username;
            this.Update_NameTb.Text = user.Ime;
            this.Update_SurnameTb.Text = user.Prezime;
            this.Update_EmailTb.Text = user.Email;
        }

        protected void UpdateUserBttn_Click(object sender, EventArgs e)
        {
            String query = "UPDATE [korisnici] SET [ime]=@ime, [prezime]=@prezime, [email]=@email WHERE [username]=@username";
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                if (this.HiddenIme.Text != "" && this.HiddenPrezime.Text != "" && this.HiddenEmail.Text != "")            
                {
                    if (Regex.IsMatch(this.HiddenEmail.Text,  @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        con.Open();

                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.Parameters.AddWithValue("@ime", this.HiddenIme.Text.ToString());
                        cmd.Parameters.AddWithValue("@prezime", this.HiddenPrezime.Text);
                        cmd.Parameters.AddWithValue("@email", this.HiddenEmail.Text);
                        cmd.Parameters.AddWithValue("@username", HttpContext.Current.User.Identity.Name);

                        cmd.ExecuteNonQuery();

                        Session.Add("info", "Podaci uspješno promjenjeni!");
                        Response.Redirect("Index.aspx", false);
                    }   
                    else
                    {
                        ErrorMessage("Email adresa nije ispravna");
                    } 
                }
                else
                {
                    ErrorMessage("Popunite sva polja");
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