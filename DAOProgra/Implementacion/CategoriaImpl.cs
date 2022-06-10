using DAOProgra.interfaces;
using DAOProgra.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Implementacion
{
    public class CategoriaImpl : BaseImpl, Icategoria
    {
        public int Delete(Categoria t)
        {
            string query = @"UPDATE Categoria
                            SET estado = 0,fechaActualizacion = CURRENT_TIMESTAMP
                            WHERE id = @id";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(Categoria t)
        {
            string query = @"INSERT INTO Categoria(nombre,nivel)
                            VALUES(@nombre,@nivel)";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@nivel", t.Nivel);
            try
            {
                return ExecuteCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable Select()
        {
            string query = @"SELECT id as ID,nombre as 'Nombre Categoria',nivel as Nivel,estado as Estado,fechaRegistro as 'Fecha Creación', fechaActualizacion as 'Fecha de Actualizacion' FROM CATEGORIA WHERE estado = 1";
            SqlCommand command = CreateCommand(query);
            try
            {
                return ExecuteSelectCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable SelectIdName()
        {
            string query = @"SELECT id,nombre FROM Categoria WHERE estado = 1";
            SqlCommand command = CreateCommand(query);
            try
            {
                return ExecuteSelectCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Categoria t)
        {
            string query = @"UPDATE Categoria
                            SET nombre=@nombre, nivel=@nivel
                            WHERE id = @id";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@nivel", t.Nivel);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
