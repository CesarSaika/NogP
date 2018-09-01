using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nogueira.NogueiraDAO
{
    public class Conexao
    {
        public OleDbConnection ConectarAccess(ref OleDbConnection con)
        {
            if (con != null)
            {
                con.Dispose();
            }
            con = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConString"].ConnectionString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return con;
        }

        public OleDbConnection ConectarExcel(ref OleDbConnection con, ref string conStr)
        {
            if (con != null)
            {
                con.Dispose();
            }
            con = new OleDbConnection(conStr);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch
            {
                throw;
            }
            return con;
        }
    }
}
