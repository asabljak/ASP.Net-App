using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AntunIT
{
    public class DatabaseHelper
    {
        public static List<String> getDropDownItems(String query)
        {
            String tmpItem;
            List<String> lista = new List<String>();
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbDataReader data = cmd.ExecuteReader();
                String lastWord = query.Split(' ').Last();

                while (data.Read())
                {
                    switch (lastWord)
                    {
                        case "tinta": tmpItem = data.GetValue(0).ToString() + " - " + data.GetValue(2) + " " + data.GetValue(1); break;
                        case "papir": tmpItem = data.GetValue(0).ToString() + " - " + data.GetValue(1) + " " + data.GetValue(2) + " - " + data.GetValue(3) + " kom"; break;
                        default: tmpItem = data.GetValue(0).ToString() + " - " + data.GetValue(1) + " " + data.GetValue(2) + " - " + data.GetValue(3); break;
                    }

                    lista.Add(tmpItem);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

            return lista;
        }

        public static List<Printer> getPrinters(String query)
        {
                Printer tmpPrinter;
                List<Printer> lista = new List<Printer>();
                OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand(query, con);
                    OleDbDataReader data = cmd.ExecuteReader();
                    String lastWord = query.Split(' ').Last();

                    while (data.Read())
                    {
                        tmpPrinter = new Printer(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), 0); 
                        lista.Add(tmpPrinter);
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }

                return lista;
        }

        public static List<PotrosniMaterijal> getPaperInk(String query)
        {
            PotrosniMaterijal tmpItem = null;
            List<PotrosniMaterijal> lista = new List<PotrosniMaterijal>();
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbDataReader data = cmd.ExecuteReader();
                String lastWord = query.Split(' ').Last();

                while (data.Read())
                {
                    switch (lastWord)
                    {
                        case "tinta": tmpItem = new Tinta(data.GetInt32(0), data.GetString(1), data.GetString(2)); break; //tmpItem = data.GetValue(0).ToString() + " - " + data.GetValue(2) + " " + data.GetValue(1); break;
                        case "papir": tmpItem = new Papir(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetInt32(3)); break; //data.GetValue(0).ToString() + " - " + data.GetValue(1) + " " + data.GetValue(2) + " - " + data.GetValue(3) + " kom"; break;
                        //default: tmpItem = null;//tmpPrinter = new Printer(data.GetInt32(0), data.GetString(1), data.GetString(2), null, data.GetString(3), 0); break;
                    }

                    lista.Add(tmpItem);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

            return lista;
        }


        public static String getLocation(String idPrinter)
        {
            String location;
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT lokacija FROM pisaci WHERE ID=@id ", con);
                cmd.Parameters.AddWithValue("@id", idPrinter);
                OleDbDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    location=data.GetString(0);
                    return location;
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

            return null;
        }


        public static void update(String query, String set, String where)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@set", set);
                cmd.Parameters.AddWithValue("@where", where);

                cmd.ExecuteNonQuery();           
            }
            catch (Exception ex)
            {
                //this.ErrorLabel.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        public static User getUser(String username)
        {
            User user = new User();
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM korisnici WHERE username=@user ", con);
                cmd.Parameters.AddWithValue("@user", username);
                OleDbDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    user.ID = data.GetInt32(0);
                    user.Ime = data.GetString(1);
                    user.Prezime = data.GetString(2);
                    user.Email = data.GetString(3);
                    user.Username = data.GetString(4);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

            return user;
        }

        public static int GetMaxId(String table)
        {
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);
            int rez = 0;

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT MAX(ID) FROM " + table, con);
                OleDbDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    rez = data.GetInt32(0);
                }
            }
            catch
            {
                
            }
            finally
            {
                con.Close();
            }

            return rez;
        }

        public static OleDbDataReader search(String query, String term)
        {
            GridView gv = new GridView();
            OleDbDataReader data = null;
            OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["dbc"].ConnectionString);

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@string", term);

                data = cmd.ExecuteReader();

                //gv.AllowPaging = false;
                //gv.DataSourceID = null;
                //gv.DataSource = data;
                //gv.DataBind();
            }
            catch 
            { 
            }
            finally
            {
                con.Close();
            }

            return data;
        }
    }
}