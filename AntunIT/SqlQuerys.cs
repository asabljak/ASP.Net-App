using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntunIT
{
    public sealed class SqlQuerys
    {
        public static readonly String SELECT_PRINTERS_QUERY = "SELECT id, naziv, model, vrsta, lokacija FROM pisaci";
        public static readonly String SELECT_TINTA_QUERY = "SELECT id, model, tip FROM tinta";
        public static readonly String SELECT_PAPIR_QUERY = "SELECT id, tip, format, komada FROM papir";
        //public static readonly String SEARCH_PRINTERS_QUERY = "SELECT ID, Naziv, Model, Vrsta, Lokacija FROM pisaci WHERE Naziv LIKE '%' + @string + '%' OR Model LIKE '%' + @string + '%'";
        public static readonly String SEARCH_PRINTERS_QUERY = "SELECT pisaci.ID, pisaci.naziv AS Pisač, pisaci.Model, pisaci.vrsta AS VrstaPisača, tinta.model AS VrstaTinte, evidencijaTinte.Dodano FROM pisaci INNER JOIN (tinta INNER JOIN evidencijaTinte ON tinta.ID = evidencijaTinte.idTinte) ON pisaci.ID = evidencijaTinte.idPrinter WHERE pisaci.naziv LIKE '%' + @string + '%' OR pisaci.Model LIKE '%' + @string + '%'";
        public static readonly String SEARCH_PAPIR_QUERY = "SELECT pisaci.ID, pisaci.naziv AS Pisač, pisaci.Model, pisaci.vrsta AS VrstaPisača, papir.tip AS VrstaPapira, papir.Format, papir.Komada, evidencijaPapira.Dodano FROM pisaci INNER JOIN (papir INNER JOIN evidencijaPapira ON papir.ID = evidencijaPapira.idPapir) ON pisaci.ID = evidencijaPapira.idPrinter WHERE pisaci.naziv LIKE '%' + @string + '%' OR pisaci.Model LIKE '%' + @string + '%'";
    }
}