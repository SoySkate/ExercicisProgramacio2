using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicisProgramacio2.Models
{
    class Article
    {
        public int CodiArt { get; set; }
        public Iva CodiClassIva { get; set; }

        public Article(int c, Iva i)
        {
            CodiArt = c;
            CodiClassIva = i;
        }
        public string escriureArtData()
        {
            return "Codigo artículo: " + CodiArt + ", y esto es el tipo iva: " + CodiClassIva;
        }
    }
}
