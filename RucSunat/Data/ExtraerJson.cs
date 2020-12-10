using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RucSunat.Logic;
using System.Net;

namespace RucSunat.Data
{
    public class ExtraerJson
    {
        private List<String[]> Convertir { get; } = new List<string[]>
        {
            new string[]
            { "Â", "", "Â¡", "¡", "Â¢", "¢", "Â£", "£", "¤", "Â¥", "¥", "Â¦", "¦", "Â§", "§", "Â¨", "¨", "Â©", "©","Âª", "ª", "Â«", "«", "Â", "",
              "Â­", "­", "Â®", "®", "Â¯", "¯", "Â°", "°", "Â±", "±", "Â²", "²", "Â³", "³", "Â´", "´", "Âµ", "µ", "Â", "", "Â·", "·", "Â¸", "¸", "Â¹",
              "¹", "Âº", "º", "Â»", "»", "Â¼", "¼", "Â½", "½", "Â¾", "¾", "Â¿", "¿", "Ã€", "À", "Ã\u0081", "Á", "Ã‚", "Â", "Ãƒ", "Ã", "Ã„", "Ä", "Ã…",
              "Å", "Ã†", "Æ", "Ã‡", "Ç", "Ãˆ", "È", "Ã‰", "É", "ÃŠ", "Ê", "Ã‹", "Ë", "ÃŒ", "Ì", "Ã\u008d", "Í", "ÃŽ", "Î", "Ã\u008f", "Ï", "Ã\u0090",
              "Ð", "Ã‘", "Ñ", "Ã’", "Ò", "Ã“", "Ó", "Ã”", "Ô", "Ã•", "Õ", "Ã–", "Ö", "Ã—", "×", "Ã˜", "Ø", "Ã™", "Ù", "Ãš", "Ú", "Ã›", "Û", "Ãœ", "Ü",
              "Ã\u009d", "Ý", "Ãž", "Þ", "ÃŸ", "ß", "Ã", "à", "Ã¡", "á", "Ã¢", "â", "Ã£", "ã", "Ã¤", "ä", "Ã¥", "å", "Ã¦", "æ", "Ã§", "ç", "Ã¨", "è",
              "Ã©", "é", "Ãª", "ê", "Ã«", "ë", "Ã", "ì", "Ã­", "í", "Ã®", "î", "Ã¯", "ï", "Ã°", "ð", "Ã±", "ñ", "Ã²", "ò", "Ã³", "ó", "Ã´", "ô", "Ãµ",
              "õ", "Ã", "ö", "Ã·", "÷", "Ã¸", "ø", "Ã¹", "ù", "Ãº", "ú", "Ã»", "û", "Ã¼", "ü", "Ã½", "ý", "Ã¾", "þ", "Ã¿", "ÿ" }
        };
        private string EquivalenciaUtF8(string dato)
        {
            string text = dato;
            foreach (string[] array in this.Convertir)
            {
                bool flag = text.Contains(array[0]);
                if (flag)
                {
                    text = text.Replace(array[0], array[1]);
                }
            }
            return text;
        }
        public Persona ConsultarDni(string dni)
        {
            Persona result = null;
            try
            {
                WebClient webClient = new WebClient();
                string text = webClient.DownloadString("https://dni.optimizeperu.com/api/persons/" + dni + "?format=json");
                bool flag = text.Length > 3;
                if (flag)
                {
                    text = text.Replace("\"", "");
                    text = text.Replace("{", "");
                    text = text.Replace("}", "");
                    text = this.EquivalenciaUtF8(text);
                    string[] array = text.Split(new char[] {
                        ','
                    });
                    result = new Persona
                    {
                        Dni = array[0].Split(new char[]
                        {
                            ':'
                        })[1],
                        Nombres = array[1].Split(new char[]
                        {
                            ':'
                        })[1],
                        PriApe = array[2].Split(new char[]
                        {
                            ':'
                        })[1],
                        SegApe = array[3].Split(new char[]
                        {
                            ':'
                        })[1]
                    };
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public Compania ObtenerContribuyente(string Ruc)
        {
            Compania result = null;
            try
            {
                WebClient webClient = new WebClient();
                string text = webClient.DownloadString("https://dni.optimizeperu.com/api/company/" + Ruc + "?format=json");
                bool flag = text.Length > 3;
                if (flag)
                {
                    string[] array = text.Split(new string[]
                    {
                        "\",\""
                    }, StringSplitOptions.None);
                    array[0] = array[0].Replace("{", "");
                    array[array.Length - 1] = array[array.Length - 1].Replace("}", "");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = array[i].Replace("\"", "");
                    }
                    compania = new Compania
                    {
                        ruc = array[0].Split(new char[]
                        {
                            ':'
                        })[1],
                        razon_social = array[1].Split(new char[]
                        {
                            ':'
                        })[1],
                        ciiu = array[2].Split(new char[]
                        {
                            ':'
                        })[1],
                        fecha_actividad = DateTime.Parse(array[3].Split(new char[]
                        {
                            ':'
                        })[1]),
                        contribuyente_condicion = array[4].Split(new char[]
                        {
                            ':'
                        })[1],
                        contribuyente_tipo = array[5].Split(new char[]
                        {
                            ':'
                        })[1],
                        contribuyente_estado = array[6].Split(new char[]
                        {
                            ':'
                        })[1],
                        nombre_comercial = array[7].Split(new char[]
                        {
                            ':'
                        })[1],
                        fecha_inscripcion = DateTime.Parse(array[8].Split(new char[]
                        {
                            ':'
                        })[1]),
                        domicilio_fiscal = array[9].Split(new char[]
                        {
                            ':'
                        })[1],
                        sistema_emision = array[10].Split(new char[]
                        {
                            ':'
                        })[1],
                        sistema_contabilidad = array[11].Split(new char[]
                        {
                            ':'
                        })[1],
                        actividad_exterior = array[12].Split(new char[]
                        {
                            ':'
                        })[1],
                        emision_electronica = array[13].Split(new char[]
                        {
                            ':'
                        })[1],
                        fecha_inscripcion_ple = DateTime.Parse(array[14].Split(new char[]
                        {

                        })[1]),
                        oficio = array[15].Split(new char[]
                        {
                            ':'
                        })[1],
                        fecha_baja = DateTime.Parse(array[16].Split(new char[] {
                            ':'
                        })[1]),
                    };
                }

            }catch
            {
                result = null;
            }
            return result;
        }
    }
}
