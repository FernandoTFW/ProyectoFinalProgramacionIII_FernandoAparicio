using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Modelo
{
    public class Categoria:BaseModel
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }

        public Categoria(short id, string nombre, string nivel, byte status, DateTime registrationDate, DateTime lastUpdate) : base(status, registrationDate, lastUpdate)
        {
            Id = id;
            Nombre = nombre;
            Nivel = nivel;
        }

        public Categoria(string nombre, string nivel)
        {
            Nombre = nombre;
            Nivel = nivel;
        }

        
    }
}
