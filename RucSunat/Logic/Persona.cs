using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RucSunat.Logic
{
    public class Persona
    {
        public string Dni { get; set; }

        public string Nombres { get; set; }

        public string PriApe { get; set; }

        public string SegApe { get; set; }

        public override string ToString()
        {
            return string.Concat(new string[] {
                "Dni: ", this.Dni,
                "\nNombres: ", this.Nombres,
                "\nPrimer Apellido: ", this.PriApe,
                "\nSegundo Apellido: ", this.SegApe,
            });
        }
    }
}
