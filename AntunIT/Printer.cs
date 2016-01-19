using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntunIT
{
    public class Printer
    {
        public int id { get; set; }
        public String naziv { get; set; }
        public String model { get; set; }
        public String vrsta { get; set; }
        public String lokacija { get; set; }
        public int dodaoID { get; set; }

        public Printer(int id, String naziv, String model, String vrsta, String lokacija, int dodaoID)
        {
            this.id = id;
            this.naziv = naziv;
            this.model = model;
            this.vrsta = vrsta;
            this.lokacija = lokacija;
            this.dodaoID = dodaoID;
        }

        public override string ToString()
        {
            return id + " - " + naziv + " " + model + ", " + vrsta.ToLower() + " - " + lokacija;
        }

    }
}