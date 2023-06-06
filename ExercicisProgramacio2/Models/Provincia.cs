using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicisProgramacio2.Models
{
    class Provincia
    {
        public int codi { get; set; }
        public string provincia { get; set; }
        public int poblacio { get; set; }

        public Provincia(int c, string p, int n)
        {
            codi = c;
            provincia = p;
            poblacio = n;
        }
        public string EscribirData()
        {
            return codi + "///" + provincia + "///" + poblacio;
        }

    }
}
