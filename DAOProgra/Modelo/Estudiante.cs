using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Modelo
{
    public class Estudiante:BaseModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PuntosFuertes { get; set; }
        public string Nivel { get; set; }
        public int IdEquipo { get; set; }

        public Estudiante(string nombre, string primerApellido, string segundoApellido, string puntosFuertes, string nivel)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            PuntosFuertes = puntosFuertes;
            Nivel = nivel;
        }

        public Estudiante(int id, string nombre, string primerApellido, string segundoApellido, string puntosFuertes, string nivel, byte status, DateTime registrationDate, DateTime lastUpdate) : base(status, registrationDate, lastUpdate)
        {
            Id = id;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            PuntosFuertes = puntosFuertes;
            Nivel = nivel;
        }
    }
}
