using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class ObrisiPrinter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void printWarning(object sender, GridViewDeleteEventArgs e)
        {
            //Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "Upozorenje", "return confirm('Jeste li sigurni da se želite odjaviti?');");
            String scriptText = "return confirmLogout())";
            ClientScript.RegisterClientScriptBlock(this.GetType(),
                "ConfirmSubmit", scriptText,true);
        }
    }
}