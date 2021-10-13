using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211013_2
{
    class Kategoria
    {
        public string Nev { get; set; }
        public int Tulelok { get; set; }
        public int Eltuntek { get; set; }
        public int Utas => Tulelok + Eltuntek; 

        public Kategoria(params string[] t)
        {
            Nev = t[0];
            Tulelok = int.Parse(t[1]);
            Eltuntek = int.Parse(t[2]);
        }
    }
}
