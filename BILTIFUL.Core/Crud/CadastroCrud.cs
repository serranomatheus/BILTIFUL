using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Core.Crud
{
    internal class CadastroCrud
    {
        
                
        private static string datasource = @"DESKTOP-TCJTUCH";//instancia do servidor
        private static string database = "biltiful"; //Base de Dados
        private static string username = "sa"; //usuario da conexão
        private static string password = "170495";

       static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                    + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
        
        SqlConnection connection = new SqlConnection(connString);
        public void InserirProduto (Produto produto)
        {
            try
            {
                using (connection)


                {
                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Produto", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;                

                    sql_cmnd.Parameters.AddWithValue("@Nome", SqlDbType.NVarChar).Value = produto.Nome;
                    sql_cmnd.Parameters.AddWithValue("@ValorVenda", SqlDbType.Float).Value = float.Parse(produto.ValorVenda);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void InserirCliente (Cliente cliente)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)

                {
                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Cliente", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@CPF", SqlDbType.NVarChar).Value = cliente.CPF;
                    sql_cmnd.Parameters.AddWithValue("@Nome", SqlDbType.NVarChar).Value = cliente.Nome;
                    sql_cmnd.Parameters.AddWithValue("@DataNascimento",cliente.DataNascimento);
                    sql_cmnd.Parameters.AddWithValue("@Sexo", SqlDbType.Char).Value = (char)cliente.Sexo;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void InserirMateriaPrima(MPrima mPrima)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)

                {
                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_MPrima", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = mPrima.Id;
                    sql_cmnd.Parameters.AddWithValue("@Nome", SqlDbType.NVarChar).Value = mPrima.Nome;                                    
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public string Count()
        {
            connection.Open();
            string query = "select count(*) from MPrima";
            var reader = new SqlCommand(query, connection).ExecuteReader();
            reader.Read();
            string cod = "MP" + (reader.GetInt32(0) + 1).ToString().PadLeft(4, '0');
            connection.Close();
            return cod;
            
        }
      
        public void InserirFornecedor(Fornecedor fornecedor)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)

                {
                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Fornecedor", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CNPJ", SqlDbType.NVarChar).Value = fornecedor.CNPJ;
                    sql_cmnd.Parameters.AddWithValue("@RazaoSocial", SqlDbType.NVarChar).Value = fornecedor.RazaoSocial;
                    sql_cmnd.Parameters.AddWithValue("@DataAbertura", fornecedor.DataAbertura);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       public void InserirBloqueado(string cnpj)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)

                {
                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Bloqueado", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CNPJ_Fornecedor", SqlDbType.NVarChar).Value = cnpj;                    
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}



