using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntunIT
{
    public class Tinta : PotrosniMaterijal
    {
        public String model { get; set; }
        public String tip { get; set; }

        public Tinta(int id, String model, String tip)
        {
            this.id = id;
            this.model = model;
            this.tip = tip;
        }

        public override string ToString()
        {
            return id + " - " + model + " " + tip;
        }
        
    }
}