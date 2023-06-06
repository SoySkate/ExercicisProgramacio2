using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicisProgramacio2.Models
{
    class Albara
    {
        public int CodiAlbara { get; set; }
        public Article CodiClassArt { get; set; }

        public int UnidadesArt { get; set; }
        public double PrecioArt { get; set; }

        public Albara(int codiAlb, Article codiArt, int ud, double precio)
        {
            CodiAlbara = codiAlb;
            CodiClassArt = codiArt;
            UnidadesArt = ud;
            PrecioArt = precio;
        }

        public string escribirDataAlbara()
        {
            return "Codigo Albaran: " + CodiAlbara + ", Codigo Articulo: " + CodiClassArt + ", Unidades Articulo: " + UnidadesArt + ", Precio Articulo: " + PrecioArt;
        }
    }
}
