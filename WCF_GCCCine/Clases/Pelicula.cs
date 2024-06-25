using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_GCCCine.Model;

namespace WCF_GCCCine.Clases
{
    public class Pelicula
    {
        public int PeliculaID { get; set; }
        public string Titulo { get; set; }
        public String Genero { get; set; }
        public String Duracion { get; set; }


    }
}