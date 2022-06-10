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
    public class EquipoImpl : BaseImpl, IEquipo
    {
        public int Delete(Equipo t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Equipo t)
        {
            EstudianteImpl estudianteImpl = new EstudianteImpl();
            string query = @"INSERT INTO Equipo(nombre,idCategoria)
                            VALUES(@nombre,@categoria)";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@categoria", t.Categoria);
            try
            {
                ExecuteCommand(command);
                estudianteImpl.UpdateEquipo(t.Integrantes);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Equipo get(short id)
        {
            string query = @"SELECT E.id,E.nombre,E.idCategoria,C.nombre FROM Equipo E INNER JOIN Categoria C ON C.id = E.idCategoria  WHERE E.id=@id";
            SqlDataReader reader = null;
            Equipo e = null;
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                reader = ExecDataReader(command);
                while (reader.Read())
                {
                    e = new Equipo(short.Parse(reader[0].ToString()), reader[1].ToString(),short.Parse(reader[2].ToString()), reader[3].ToString());

                }
                return e;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Select()
        {
            string query = @"SELECT E.id as ID,E.nombre as 'Nombre del Equipo', C.nombre as Categoria, (SELECT CONCAT(Es.nombre,' ',Es.primerApellido) 
                            FROM Estudiante Es WHERE id = E.idLider) AS 'Lider del Equipo' FROM Equipo E 
                            INNER JOIN Categoria C ON C.id = E.idCategoria";
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

        public int Update(Equipo t)
        {
            throw new NotImplementedException();
        }

        public int UpdateLider(Equipo t)
        {
            string query = @"UPDATE Equipo
                            SET idLider = @idLider
                            WHERE id = @id";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@idLider", t.Lider);
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
