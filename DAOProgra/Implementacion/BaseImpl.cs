using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Implementacion
{
    public class BaseImpl
    {
        string connectionString = @"Server=FERNANDO-PC\SQLEXPRESS;Database=bddPrograIII;User Id=sa;Password=Univalle;";

        public string SelectPath()
        {
            string query = @"SELECT pathFotoEquipo FROM Config";
            SqlCommand command = CreateCommand(query);
            try
            {
                return ExecuteScalarCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SqlCommand CreateCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public SqlCommand CreateCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }

        public List<SqlCommand> CreateCommand(int index)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);
            for (int i = 0; i < index; i++)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                commands.Add(command);
            }
            return commands;
        }

        public int ExecuteCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public string ExecuteScalarCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataTable ExecuteSelectCommand(SqlCommand command)
        {
            try
            {

                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public SqlDataReader ExecDataReader(SqlCommand command)
        {
            SqlDataReader reader = null;
            try
            {

                command.Connection.Open();
                reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return reader;
        }

        public void ExecuteTransaction(List<SqlCommand> commands)
        {
            SqlTransaction tran = null;
            try
            {
                commands[0].Connection.Open();
                tran = commands[0].Connection.BeginTransaction();
                foreach (SqlCommand command in commands)
                {
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }

                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                commands[0].Connection.Close();
            }
        }

        public string LastIndex(string table)
        {
            string query = @"SELECT IDENT_CURRENT('" + table + "')+IDENT_INCR('" + table + "')";
            SqlCommand command = CreateCommand(query);
            try
            {
                return ExecuteScalarCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
