using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = DatabaseHelper.getUser(HttpContext.Current.User.Identity.Name);

            this.Profil_Username.Text = user.Username;
            this.Profil_Ime.Text = user.Ime;
            this.Profil_Prezime.Text = user.Prezime;
            this.Profil_Email.Text = user.Email;
        }
    }
}