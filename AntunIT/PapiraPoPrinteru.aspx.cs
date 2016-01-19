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
    public partial class PapiraPoPrinteru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Trazi(object sender, EventArgs e)
        {
            String term = String.Empty;
            Button b = (Button)sender;
            if (b.ID.Equals("TraziBttn"))
                term = this.TraziTb.Text;
            else
                Response.Redirect(Request.RawUrl);

            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(SqlQuerys.SEARCH_PAPIR_QUERY, con);
                cmd.Parameters.AddWithValue("@string", term);

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

        protected void makniSearch(object sender, GridViewSortEventArgs e)
        {
            this.content.Visible = false;
            this.PonistiFilterBttn.Visible = true;
        }

    }
}