using AcessoBancoDeDados.Properties;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AcessoBancoDeDados
{
    public class AcessoDadosSQLServer
    {        
        /// definir a string de conexão com o banco na configuração do App no VS
        public SqlConnection Criarconexao()
        {
            return new SqlConnection(Settings.Default.StringConexao);
        }
       
        private readonly SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }
      
        // persistencia - inserir, alterar (update - atualizar), e excluir
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedure)
        {
            try
            {
                using (SqlConnection sqlconnection = Criarconexao())
                {
                    sqlconnection.Open();
                    SqlCommand sqlcommand = sqlconnection.CreateCommand();
                    sqlcommand.CommandType = commandType;
                    sqlcommand.CommandText = nomeStoredProcedure;
                    sqlcommand.CommandTimeout = 60;
                    foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    {
                        sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    return sqlcommand.ExecuteScalar();
                }
            }

            catch (Exception Exception)
            {
                throw new Exception(Exception.Message);
            }

        }

        public DataTable ExecutarConsulta(CommandType commandType, 
            string nomeStoredProcedure)
        {
            try
            {
                using (SqlConnection sqlconnection = Criarconexao())
                {
                    sqlconnection.Open();
                    SqlCommand sqlcommand = sqlconnection.CreateCommand();
                    sqlcommand.CommandType = commandType;
                    sqlcommand.CommandText = nomeStoredProcedure;
                    sqlcommand.CommandTimeout = 60;
                    foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    {
                        sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }              

        public DataTable ExecutarConsultaSemParametros(
            CommandType commandType, string nomeStoredProcedure)
        {
            try
            {

                using (SqlConnection sqlconnection = Criarconexao())
                {
                    sqlconnection.Open();
                    SqlCommand sqlcommand = sqlconnection.CreateCommand();
                    sqlcommand.CommandType = commandType;
                    sqlcommand.CommandText = nomeStoredProcedure;
                    sqlcommand.CommandTimeout = 60;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }


            catch (Exception Exception)
            {
                throw new Exception(Exception.Message);
            }
        }     
    }
}

