using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Implementacion
{
    public static class Controladores
    {
        public static CategoriaImpl controladorCategoria = new CategoriaImpl();
        public static EquipoImpl controladorEquipo = new EquipoImpl();
        public static EstudianteImpl controladorEstudiante = new EstudianteImpl();
        public static List<string> Niveles = new List<string>()
        {
            "Junior",
            "Master",
            "Senior"
        };
    }
}
