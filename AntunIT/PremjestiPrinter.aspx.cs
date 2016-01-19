using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class PremjestiPrinter : System.Web.UI.Page
    {
        String idPrinter;
        protected void Page_Load(object sender, EventArgs e)
        {
            String query = "SELECT ID, Naziv, Model, Lokacija FROM pisaci";
            List<String> lista = new List<String>();

            if (!IsPostBack)
            {
                lista = DatabaseHelper.getDropDownItems(query);
                this.PrineriZaPremjestanjeDropDown.DataSource = lista;
                this.PrineriZaPremjestanjeDropDown.DataBind();
            }

            idPrinter = this.PrineriZaPremjestanjeDropDown.Text.Split(' ').First();
            this.NovaLokacijaTb.Text = DatabaseHelper.getLocation(idPrinter);
        }

        protected void PrineriZaPremjestanjeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPrinter = this.PrineriZaPremjestanjeDropDown.Text.Split(' ').First();
            this.NovaLokacijaTb.Text = DatabaseHelper.getLocation(idPrinter);
        }

        protected void PromijeniLokacijuBttn_Click(object sender, EventArgs e)
        {
            if (this.HiddenLokacija.Text.Equals("") || this.HiddenLokacija.Text.StartsWith(" "))
            {
                ErrorMessage("Željena lokacija ne smije biti prazna ili započinjati s razmakom");
            }
            else
            {
                DatabaseHelper.update("UPDATE [pisaci] SET [lokacija] = @sto WHERE [id] = @gdje", this.HiddenLokacija.Text, this.PrineriZaPremjestanjeDropDown.Text.Split(' ').First());

                Session.Add("info", "Pisač uspješno premješten!");
                Response.Redirect("Index.aspx", false); 
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