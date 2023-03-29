using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort
{
    public class Nodo
    {
        public int NumeroCelda { get; set; }
        public (int, int) Coordenada { get; set; }
        public List<Adyacente> Adyacentes { get; set; }

    }
}
