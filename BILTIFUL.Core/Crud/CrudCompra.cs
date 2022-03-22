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
    public class CrudCompra
    {

        private static string datasource = @"DESKTOP-TCJTUCH";//instancia do servidor
        private static string database = "biltiful"; //Base de Dados
        private static string username = "sa"; //usuario da conexão
        private static string password = "170495";

        static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                     + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;


        public void InserirCompra(Compra compra) 
        {
            SqlConnection connection = new SqlConnection(connString);
           
            
                using (connection)
                {

                    connection.Open();

                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Compra", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CNPJ_fornecedor", SqlDbType.NVarChar).Value = compra.Fornecedor;
                    sql_cmnd.Parameters.AddWithValue("@ValorTotal", SqlDbType.Float).Value = compra.ValorTotal;                    
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            
        }

        public void InserirItemCompra(ItemCompra itemCompra)
        {
            SqlConnection connection = new SqlConnection(connString);


            using (connection)
            {

                connection.Open();

                SqlCommand sql_cmnd = new SqlCommand("Inserir_ItemCompra", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID_ItemCompra", SqlDbType.Float).Value = itemCompra.ItemCompraID;
                sql_cmnd.Parameters.AddWithValue("@Quantidade", SqlDbType.Float).Value = itemCompra.Quantidade;
                sql_cmnd.Parameters.AddWithValue("@ValorUnitario", SqlDbType.Float).Value = itemCompra.ValorUnitario;
                sql_cmnd.Parameters.AddWithValue("@TotalItem", SqlDbType.Float).Value = itemCompra.TotalItem;
                sql_cmnd.Parameters.AddWithValue("@Id_Compra_IC", SqlDbType.Float).Value = itemCompra.Id;
                sql_cmnd.Parameters.AddWithValue("@ID_MPrima_IC", SqlDbType.NVarChar).Value = itemCompra.MateriaPrima;
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public int Count()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "select count(*) from Compra";
            var reader = new SqlCommand(query, connection).ExecuteReader();
            reader.Read();
            int cod =  reader.GetInt32(0);
            connection.Close();
            return cod;

        }

        public bool PesquisarMPrimaID(string buscar)
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    connection.Open();

                    String sql = "SELECT Id , Nome FROM dbo.MPrima WHERE Id = '" + buscar + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Console.WriteLine("\t\t\t\t\t------------------------------------------ -\n\t\t\t\t\tId:{0}\n\t\t\t\t\tNome:{1}", reader.GetString(0), reader.GetString(1));
                                return true;
                            }
                        }
                    }
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool PesquisarMPrima(string buscar)
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    connection.Open();   
                    
                    String sql = "SELECT Id, Nome FROM dbo.MPrima WHERE Nome = '" + buscar+"'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               
                                Console.WriteLine("\t\t\t\t\t------------------------------------------ -\n\t\t\t\t\tId:{0}\n\t\t\t\t\tNome:{1}" ,reader.GetString(0), reader.GetString(1));
                                return true;
                            }
                        }
                    }                    
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool PesquisarCNPJ(string cnpj)
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)                    
                
                {                    
                    connection.Open();

                    String sql = "SELECT RazaoSocial, CNPJ  FROM dbo.Fornecedor WHERE CNPJ = " + cnpj;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {


                                Console.WriteLine("\t\t\t\t\tFornecedor:\t{0}\n\t\t\t\t\tCnpj:\t {1}", reader.GetString(0), reader.GetString(1));
                                return true;
                            }
                           
                        }
                       
                    }
                    
                    connection.Close();
                    
                    return false;
                }
            }
            catch
            {
                
                
                return false;
            }
        }

        public bool PesquisarBloqueado(string cnpj)
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)


                {

                    connection.Open();

                    String sql = "SELECT CNPJ_Fornecedor  FROM dbo.Bloqueado WHERE CNPJ_Fornecedor = " + cnpj;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Console.WriteLine("\t\t\t\t\tCompra indisponivel para esse fornecedor");
                                Console.WriteLine("\t\t\t\t\tCnpj:\t {0}", reader.GetString(0));
                                
                                return true;
                            }

                        }

                    }

                    connection.Close();

                    return false;
                }
            }
            catch
            {


                return false;
            }
        }

        public bool LocalizarCompraCNPJ(string cnpj)
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    connection.Open();

                    String sql = "SELECT Id ,CNPJ_fornecedor, DataCompra, ValorTotal FROM dbo.MPrima WHERE CNPJ_fornecedor = '" + cnpj + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Console.WriteLine("\t\t\t\t\t------------------------------------------ -\n\t\t\t\t\tId: {0}\n\t\t\t\t\tFornecedor: {1} \n\t\t\t\t\tDataCompra: {2}\n\t\t\t\t\tValor Total: {3}", reader.GetInt32(0), reader.GetString(1),reader.GetDateTime(2),reader.GetDouble(3));
                                return true;
                            }
                        }
                    }
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
    }

