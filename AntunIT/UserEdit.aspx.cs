using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Text;

namespace AntunIT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.Name.Equals("admin") == false)
            {
                Response.Redirect("Index.aspx");
            }
            //if (!this.IsPostBack)
            //{
            //    //Populating a DataTable from database.
            //    DataTable dt = this.GetData();

            //    //Building an HTML string.
            //    StringBuilder html = new StringBuilder();

            //    //Table start.
            //    html.Append("<table class='editTablica' border='1' >");

            //    //Building the Header row.
            //    html.Append("<tr>");
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        html.Append("<th>");
            //        html.Append(column.ColumnName);
            //        html.Append("</th>");
            //    }
            //    html.Append("</tr>");
            //    //Building the Data rows.
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        html.Append("<tr>");
            //        foreach (DataColumn column in dt.Columns)
            //        {
            //            html.Append("<td>");
            //            html.Append(row[column.ColumnName]);
            //            html.Append("</td>");
            //        }
            //        html.Append("</tr>");
            //    }

            //    //Table end.
            //    html.Append("</table>");

            //    //Append the HTML string to Placeholder.
            //    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            //}
        }

        //private DataTable GetData()
        //{
        //    using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString))
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand("SELECT id, ime, prezime, email FROM Korisnici"))
        //        {
        //            using (OleDbDataAdapter da = new OleDbDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                da.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    da.Fill(dt);
        //                    return dt;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}