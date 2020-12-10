using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RucSunat.Logic
{
    public class Compania
    {
        public string ruc { get; set; }

        public string razon_social { get; set; }

        public string ciiu { get; set; }

        public DateTime fecha_actividad { get; set; }

        public string contribuyente_condicion { get; set; }

        public string contribuyente_tipo { get; set; }

        public string contribuyente_estado { get; set; }

        public string nombre_comercial { get; set; }

        public DateTime fecha_inscripcion { get; set; }

        public string domicilio_fiscal { get; set; }

        public string sistema_emision { get; set; }

        public string sistema_contabilidad { get; set; }

        public string actividad_exterior { get; set; }

        public string emision_electronica { get; set; }

        public DateTime fecha_inscripcion_ple { get; set; }

        public string oficio { get; set; }

        public DateTime fecha_baja { get; set; }

        public object representante_legal { get; set; }

        public string empleados { get; set; }

        public string locales { get; set; }
    }
}
