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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Trazi(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.ID.Equals("TraziBttn"))
            {
                String query = "SELECT ID, Ime, Prezime, Email FROM korisnici WHERE Ime LIKE '%' + @string + '%' OR Prezime LIKE '%' + @string + '%'";

                OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@string", this.TraziTb.Text.ToString());

                    OleDbDataReader data = cmd.ExecuteReader();

                    this.GridViewKorisnici.AllowSorting = false;
                    this.GridViewKorisnici.AllowPaging = false;
                    this.GridViewKorisnici.DataSourceID = null;
                    this.GridViewKorisnici.DataSource = data;
                    GridViewKorisnici.DataBind();
                }
                catch { }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void makniSearch(object sender, GridViewSortEventArgs e)
        {
            this.content.Visible = false;
            this.PonistiFilterBttn.Visible = true;
        }
    }
}