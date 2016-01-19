using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AntunIT
{
    /// <summary>
    /// Summary description for InksHandler
    /// </summary>
    public class InksHandler : IHttpHandler
    {
        List<PotrosniMaterijal> lista;
        List<String> inks;

        public void ProcessRequest(HttpContext context)
        {
            String term = context.Request["term"] ?? "";

            lista = DatabaseHelper.getPaperInk(SqlQuerys.SELECT_TINTA_QUERY);
            inks = new List<String>();
            foreach (Tinta t in lista)
            {
                inks.Add(t.ToString());
            }

            JavaScriptSerializer serializator = new JavaScriptSerializer();
            context.Response.Write(serializator.Serialize(inks));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}