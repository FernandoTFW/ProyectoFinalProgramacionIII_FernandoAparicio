using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Modelo
{
    public class Equipo:BaseModel
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public short Categoria { get; set; }
        public string NombreCategoria { get; set; }
        public List<Estudiante> Integrantes { get; set; }
        public int Lider { get; set; }

        public Equipo(string nombre, short categoria, List<Estudiante> integrantes, int lider)
        {
            Nombre = nombre;
            Categoria = categoria;
            Integrantes = integrantes;
            Lider = lider;
        }

        public Equipo(string nombre, short categoria, List<Estudiante> integrantes)
        {
            Nombre = nombre;
            Categoria = categoria;
            Integrantes = integrantes;
        }

        public Equipo(string nombre, short categoria, List<Estudiante> integrantes, int lider, byte status, DateTime registrationDate, DateTime lastUpdate) : base(status, registrationDate, lastUpdate)
        {
            Nombre = nombre;
            Categoria = categoria;
            Integrantes = integrantes;
            Lider = lider;
        }

        public Equipo(short id, string nombre, short categoria)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
        }

        public Equipo(short id, string nombre, short categoria, string nombreCategoria) : this(id, nombre, categoria)
        {
            NombreCategoria = nombreCategoria;
        }
    }
}
