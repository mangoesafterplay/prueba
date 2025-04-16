using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04_MVC_Agreda.Models
{
    public class clsEncuestas
    {
        public string titulo { get; set; }
        public int cantidadTotal { get; set; }
        public List<clsAlternativa> alternativa { get; set; }
    }
}
