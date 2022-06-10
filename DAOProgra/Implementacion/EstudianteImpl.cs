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
    public class EstudianteImpl : BaseImpl, IEstudiante
    {
        public int Delete(Estudiante t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Estudiante t)
        {
            string query = @"INSERT INTO Estudiante(nombre,primerApellido,segundoApellido,puntosFuertes,nivel)
                            VALUES(@nombre,@primerApellido,@segundoApellido,@puntosFuertes,@nivel)";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@puntosFuertes", t.PuntosFuertes);
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
            string query = @"SELECT id as ID,nombre as 'Nombre',nivel as Nivel FROM Estudiante WHERE estado = 1";
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

        public Estudiante Get(int id)
        {
            string query = @"SELECT nombre,primerApellido,segundoApellido,puntosFuertes,nivel FROM Estudiante WHERE estado = 1 AND id=@id";
            SqlDataReader reader = null;
            Estudiante e = null;
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                reader = ExecDataReader(command);
                while (reader.Read())
                {
                    if (reader[1] != System.DBNull.Value)
                    {
                        e = new Estudiante(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    }
                    else
                    {
                        e = new Estudiante(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    }

                }
                return e;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable SelectEstudianteHabilidad(string busqueda)
        {
            string query = @"SELECT id as ID,CONCAT(nombre,' ',primerApellido,' ',ISNULL(segundoApellido,''))as 'Nombre',nivel as Nivel,puntosFuertes AS Habilidades FROM Estudiante WHERE estado = 1 AND puntosFuertes LIKE '%"+ busqueda +"%'";
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

        public DataTable SelectEstudianteHabilidad(short equipo)
        {
            string query = @"SELECT id as ID,CONCAT(nombre,' ',primerApellido,' ',ISNULL(segundoApellido,''))as 'Nombre',nivel as Nivel,puntosFuertes AS Habilidades FROM Estudiante WHERE estado = 1 AND idEquipo = @idEquipo";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@idEquipo", equipo);
            try
            {
                return ExecuteSelectCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Estudiante t)
        {
            throw new NotImplementedException();
        }

        public void UpdateEquipo(List<Estudiante> t)
        {
            List<SqlCommand> commands = CreateCommand(t.Count);
            string query = @"UPDATE Estudiante SET idEquipo = @idEquipo WHERE id = @id";
            foreach (SqlCommand item in commands)
            {
                item.CommandText = query;
            }
            for (int i = 0; i < t.Count; i++)
            {
                commands[i].Parameters.AddWithValue("@idEquipo", t[i].IdEquipo);
                commands[i].Parameters.AddWithValue("@id", t[i].Id);
            }
            try
            {
                ExecuteTransaction(commands);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
