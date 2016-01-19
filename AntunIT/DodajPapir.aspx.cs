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
    public partial class DodajPapir : System.Web.UI.Page
    {
        List<PotrosniMaterijal> lista;
        List<Printer> printeri;

        protected void Page_Load(object sender, EventArgs e)
        {          
            lista = new List<PotrosniMaterijal>();
            printeri = new List<Printer>();

            if (!IsPostBack)
            {
                printeri = DatabaseHelper.getPrinters(SqlQuerys.SELECT_PRINTERS_QUERY);
                this.DropDownListPrinteri_Papir.DataSource = printeri;
                this.DropDownListPrinteri_Papir.DataBind();

                lista = DatabaseHelper.getPaperInk(SqlQuerys.SELECT_PAPIR_QUERY);
                this.DropDownListPapir_Papir.DataSource = lista;
                this.DropDownListPapir_Papir.DataBind(); 
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }


        protected void DodajPapirBttn_Click(object sender, EventArgs e)
        {
            int printerId;
            int papirId;

            String idPrinterToParse = this.DropDownListPrinteri_Papir.Text.ToString().Split(' ').First();
            String idPapirToParse = this.DropDownListPapir_Papir.Text.ToString().Split(' ').First();

            int.TryParse(idPrinterToParse, out printerId);
            int.TryParse(idPapirToParse, out papirId);

            InsertPaperToDatabase(printerId, papirId);
        }


        protected void DodajNoviPapirBttn_Click(object sender, EventArgs e)
        {
            int printerId;
            int komada;
            String query;

            String idPrinterToParse = this.DropDownListPrinteri_Papir.Text.ToString().Split(' ').First();

            printeri = DatabaseHelper.getPrinters(SqlQuerys.SELECT_PRINTERS_QUERY);
            Printer p = printeri[DropDownListPrinteri_Papir.SelectedIndex];

            int.TryParse(idPrinterToParse, out printerId);
            int.TryParse(this.NewPaperNumTb.Text, out komada);
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            if(komada<1)
            {
                ErrorMessage("Broj komada papira nije ispravan");
                return;
            }

            try
            {
                con.Open();

                query = "INSERT INTO [papir] ([tip],[format], [komada]) VALUES (@tip, @format, @komada)";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@tip", this.NewPaperNameTb.Text.ToLower());
                cmd.Parameters.AddWithValue("@format", this.NewPaperFormatTb.Text);
                cmd.Parameters.AddWithValue("@komada", komada);
                cmd.ExecuteNonQuery();

                Session.Add("info", "Papir uspješno dodan!");
                Response.Redirect("Index.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                con.Close();
            }

            InsertPaperToDatabase(printerId, DatabaseHelper.GetMaxId("papir"));
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = RadioButtonListPaper.SelectedIndex;
        }


        private void InsertPaperToDatabase(int idPrinter, int idPapir)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);
            String query = "INSERT INTO [evidencijaPapira] ([idPrinter],[idPapir],[dodano]) VALUES (@prinetr, @papir, @vrijeme)";

            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@printer", idPrinter);
                cmd.Parameters.AddWithValue("@papir", idPapir);
                cmd.Parameters.AddWithValue("@vrijeme", DateTime.Now.ToString());

                cmd.ExecuteNonQuery();

                Session.Add("info", "Papir uspješno dodan!");
                Response.Redirect("Index.aspx", false);
            }
            catch(Exception ex)
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