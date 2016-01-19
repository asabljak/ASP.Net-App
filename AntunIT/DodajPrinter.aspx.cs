using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class DodajPrinter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBttn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            if (this.NewPrinterNameTb.Text != "" && this.NewPrinterModelTb.Text != ""  && this.NewPrinterLokacijaTb.Text != "")
            {
                try
                {
                    con.Open();
                    String sql = "INSERT INTO [pisaci] ([naziv], [model], [vrsta], [lokacija], [dodaoID]) VALUES (@naziv, @model, @vrsta, @lokacija, @dodao)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.AddWithValue("@naziv", this.NewPrinterNameTb.Text.ToString());
                    cmd.Parameters.AddWithValue("@model", this.NewPrinterModelTb.Text.ToString());
                    cmd.Parameters.AddWithValue("@vrsta", this.NewPrinterTipDD.Text.ToString());
                    cmd.Parameters.AddWithValue("@lokacija", this.NewPrinterLokacijaTb.Text.ToString());
                    cmd.Parameters.AddWithValue("@dodao", getUserId(con));
                    //cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                    cmd.ExecuteNonQuery();

                    Session.Add("info", "Pisač uspješno dodan!");
                    Response.Redirect("Index.aspx", false);
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = ex.Message.ToString();
                }
                finally
                {
                    con.Close();
                } 
            }
        }


        private Int32 getUserId(OleDbConnection con)
        {
            Int32 userID;
            String username = HttpContext.Current.User.Identity.Name;

            OleDbCommand query = new OleDbCommand("SELECT id FROM Korisnici WHERE username=@ime", con);
            query.Parameters.AddWithValue("@ime", username);
            OleDbDataReader data = query.ExecuteReader();

            if (data.Read())
            {
                //Int32.TryParse(data.GetInt32(0), out userID);
                //userID = (object.)data.GetValue(0);
                userID = data.GetInt32(0);
                return userID;
            }

            return 0;
        }
    }
}