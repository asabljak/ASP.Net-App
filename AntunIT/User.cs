using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntunIT
{
    public class User
    {
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }

        public User ()
        {

        }

        public User (int id, String ime, String prezime, String email, String username)
        {
            this.ID = id;
            this.Ime = ime;
            this.Prezime = Prezime;
            this.Email = email;
            this.Username = username;
        }

    }
}