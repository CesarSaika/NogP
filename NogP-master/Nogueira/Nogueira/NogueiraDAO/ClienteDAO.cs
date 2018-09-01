using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nogueira.NogueiraDTO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Configuration;

namespace Nogueira.NogueiraDAO
{
    public class ClienteDAO
    {
        OleDbConnection conn;

        #region [Conectar Excel]
        //public void ConectarExcel(string filePath)
        //{
        //    string extension = Path.GetExtension(filePath);
        //    string conStr;

        //    conStr = string.Empty;
        //    switch (extension)
        //    {
        //        case ".xls": //Excel 97-03
        //            conStr = string.Format(ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString, filePath);
        //            break;

        //        case ".xlsx": //Excel 07
        //            conStr = string.Format(ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString, filePath);
        //            break;
        //    }

        //    Conexao con = new Conexao();
        //    conn = con.ConectarExcel(ref conn, ref conStr);
        //}
        #endregion

        public void ConectarAccess()
        {
            Conexao con = new Conexao();
            conn = con.ConectarAccess(ref conn);
        }

        internal void Cadastrar(ClienteDTO dadosCliente)
        {
            ConectarAccess();

            string comando = "INSERT INTO Clientes (telefone, nome, endereco, numero, complemento, ponto_referencia, data_aniversario)" +
                                    "values(@telefone, @nome, @endereco, @numero, @complemento, @ponto_referencia, @data_aniversario)";

            OleDbCommand cmd = new OleDbCommand(comando, conn);

            cmd.Parameters.Add("@telefone", OleDbType.VarChar).Value = dadosCliente.Telefone;
            cmd.Parameters.Add("@nome", OleDbType.VarChar).Value = dadosCliente.Nome;
            cmd.Parameters.Add("@endereco", OleDbType.VarChar).Value = dadosCliente.Endereco;
            cmd.Parameters.Add("@numero", OleDbType.VarChar).Value = dadosCliente.Numero;
            cmd.Parameters.Add("@complemento", OleDbType.VarChar).Value = dadosCliente.Complemento;
            cmd.Parameters.Add("@ponto_referencia", OleDbType.VarChar).Value = dadosCliente.PontoReferencia;
            cmd.Parameters.Add("@data_aniversario", OleDbType.VarChar).Value = dadosCliente.DataAniversario;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente Cadastrado com Sucesso!");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                if (conn != null) conn.Dispose();
            }
        }
    }
}
