using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntunIT
{
    public class Papir : PotrosniMaterijal
    {
        public String tip { get; set; }
        public String format { get; set; }
        public int komada { get; set; }

        public Papir(int id, String tip, String format, int komada)
        {
            this.id = id;
            this.tip = tip;
            this.format = format;
            this.komada = komada;
        }

        public override string ToString()
        {
            return id + " - " + tip + " " + format + " - " + komada + " kom";
        }
    }
}