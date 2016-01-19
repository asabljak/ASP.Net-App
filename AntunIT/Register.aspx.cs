using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace AntunIT
{
    public partial class Register : System.Web.UI.Page
    {
        bool korisnikPostojiFlag;
        String username;
        String password;
        String email;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnikPostojiFlag = false;
        }

        protected void RegisterBttn_Click(object sender, EventArgs e)
        {
            bool RegistrationSuccess = true;
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);
            password = Crypto.SHA256("AntunIT123");
            username = this.NewUsernameTb.Text.ToString();
            email = this.NewUserEmailTb.Text.ToString();

            if (this.NewNameTb.Text != "" && this.NewSurnameTb.Text != "" && this.NewUserEmailTb.Text != "" && NewUsernameTb.Text != "")
            {
                if(Regex.IsMatch(this.NewUserEmailTb.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    try
                    {
                        con.Open();

                        if (!userExists(con))
                        {
                            String sql = "INSERT INTO [korisnici] ([ime], [prezime], [email], [username], [password], [dateTime]) VALUES (@name, @surname, @mail, @user, @pass, @date)";
                            OleDbCommand cmd = new OleDbCommand(sql, con);
                            cmd.Parameters.AddWithValue("@name", this.NewNameTb.Text.ToString());
                            cmd.Parameters.AddWithValue("@surname", this.NewSurnameTb.Text.ToString());
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@user", username);
                            cmd.Parameters.AddWithValue("@pass", password);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            RegistrationSuccess = false;
                            if (korisnikPostojiFlag)
                            {
                                ErrorMessage("Korisničko ime već postoji. Odaberite novo");
                            }
                            else
                            {
                                ErrorMessage("Lozinke se ne podudaraju");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLabel.Text = ex.Message.ToString();
                        RegistrationSuccess = false;
                    }
                    finally
                    {
                        con.Close();
                        if (RegistrationSuccess)
                        {
                            sendEmailNotification(email);
                            Session.Add("info", "Korisnik uspješno dodan!");
                            Response.Redirect("Index.aspx");
                        }
                    }
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

        private void ErrorMessage(String text)
        {
            Panel Panel;
            Label ErrorLabel;

            Panel = (Panel)Master.FindControl("errorMessage");
            ErrorLabel = (Label)this.Master.FindControl("ErrorLabel");

            Panel.Visible = true;
            ErrorLabel.Text = text;
        }

        private bool userExists(OleDbConnection con)
        {
            OleDbCommand query = new OleDbCommand("SELECT username, password FROM Korisnici WHERE username=@ime", con);
            query.Parameters.AddWithValue("@ime", NewUsernameTb.Text.ToString());
            OleDbDataReader data = query.ExecuteReader();

            while (data.Read())
            {
                korisnikPostojiFlag = true;
                return true;
            }

            return false;
        }

        private void sendEmailNotification(String toAddress)
        {
            String subject = "Dobrodošli";
            String body = "Poštovani, \n\nkreiran Vam je korisnički račun na stranicama tvrtke AntunIT.\nVaši korisniči podaci su:\n\nKorisničko ime: " + username +
                            "\nPrivremena lozinka: AntunIT123\n\nIzmjena lozinke biti će Vam omogućena prilikom prve prijave u web aplikaciju.\n\nPozdrav,\nAntunIT";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                Credentials = new NetworkCredential("antunit@outlook.com", "Lozinka123"),
                EnableSsl = true
            };
            client.Send("antunit@outlook.com", toAddress, subject, body);
        }
    }
}