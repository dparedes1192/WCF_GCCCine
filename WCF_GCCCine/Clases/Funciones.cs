using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WCF_GCCCine.Clases
{
    public class Funciones
    {
        public int funcionId { get; set; }
        public int PeliculaId { get; set;}
        public int SalaId { get; set; }
        public DateTime Fechafuncion { get; set; }
        public double precio { get; set; }

        public Pelicula Pelicula { get; set; }
    }
}