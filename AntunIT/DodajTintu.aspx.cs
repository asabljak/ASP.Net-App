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
    public partial class DodajTintu : System.Web.UI.Page
    {
        List<PotrosniMaterijal> lista;
        List<Printer> printeri;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lista = new List<PotrosniMaterijal>();
                printeri = new List<Printer>();

                printeri = DatabaseHelper.getPrinters(SqlQuerys.SELECT_PRINTERS_QUERY);
                this.DropDownListPrinteri_Tinta.DataSource = printeri;
                this.DropDownListPrinteri_Tinta.DataBind();

                lista = DatabaseHelper.getPaperInk(SqlQuerys.SELECT_TINTA_QUERY);
                this.DropDownListPapir_Tinta.DataSource = lista;
                this.DropDownListPapir_Tinta.DataBind();
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void DodajTintuBttn_Click(object sender, EventArgs e)
        {
            int printerId;
            int tintaId;

            String idPrinterToParse = this.DropDownListPrinteri_Tinta.Text.ToString().Split(' ').First();
            String idPapirToParse = this.DropDownListPapir_Tinta.Text.ToString().Split(' ').First();

            int a=DropDownListPrinteri_Tinta.SelectedIndex;
            printeri = DatabaseHelper.getPrinters(SqlQuerys.SELECT_PRINTERS_QUERY);
            lista = DatabaseHelper.getPaperInk(SqlQuerys.SELECT_TINTA_QUERY);

            Printer p = printeri[a];
            Tinta t = (Tinta)lista[DropDownListPapir_Tinta.SelectedIndex];

            if ((p.vrsta.Equals("Laserski") && t.tip.Equals("toner")) || (p.vrsta.Equals("Tintni") && t.tip.Equals("tinta")))
            {
                int.TryParse(idPrinterToParse, out printerId);
                int.TryParse(idPapirToParse, out tintaId);

                InsertInkIntoDatabase(printerId,tintaId);

                
            }
            else
            {
                ErrorMessage("Označeni pisač i tinta nisu kompatibilni");
            }
        }

        protected void DodajNovuTintuBttn_Click(object sender, EventArgs e)
        {
            int printerId;
            String query;

            String idPrinterToParse = this.DropDownListPrinteri_Tinta.Text.ToString().Split(' ').First();

            int a = DropDownListPrinteri_Tinta.SelectedIndex;
            printeri = DatabaseHelper.getPrinters(SqlQuerys.SELECT_PRINTERS_QUERY);

            Printer p = printeri[a];

            if ((p.vrsta.Equals("Laserski") && NewInkTypeDD.Text.Equals("Toner")) || (p.vrsta.Equals("Tintni") && NewInkTypeDD.Text.Equals("Tinta")))
            {
                int.TryParse(idPrinterToParse, out printerId);
                OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

                try
                {
                    con.Open();                    

                    query = "INSERT INTO [tinta] ([model],[tip]) VALUES (@model, @tip)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@model", this.NewInkNameTb.Text);
                    cmd.Parameters.AddWithValue("@tip", this.NewInkTypeDD.Text.ToLower());
                    cmd.ExecuteNonQuery();

                    Session.Add("info", "Tinta uspješno dodana!");
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

                InsertInkIntoDatabase(printerId, DatabaseHelper.GetMaxId("tinta"));
            }
            else
            {
                ErrorMessage("Označeni pisač i tinta nisu kompatibilni");
            }
        }

        private void InsertInkIntoDatabase(int printerId, int tintaId)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);
            String query = "INSERT INTO [evidencijaTinte] ([idPrinter],[idTinte],[dodano]) VALUES (@prinetr, @tinta, @vrijeme)";

            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@printer", printerId);
                cmd.Parameters.AddWithValue("@tinta", tintaId);
                cmd.Parameters.AddWithValue("@vrijeme", DateTime.Now.ToString());

                cmd.ExecuteNonQuery();

                Session.Add("info", "Tinta uspješno dodana!");
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = RadioButtonListInk.SelectedIndex;
        }
    
    }
}