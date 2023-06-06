using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicisProgramacio2.Models
{
    class Iva
    {
        public int CodiIva { get; set; }
        public double Percentatge { get; set; }

        public Iva(int c, double p)
        {
            CodiIva = c;
            Percentatge = p;
        }
        public string escriureIvaData()
        {
            return "Este es el codigo del iva: " + CodiIva + ", y esto es el porcentage: " + Percentatge;
        }
    }
}
