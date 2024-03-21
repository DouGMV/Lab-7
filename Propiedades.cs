using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Propiedad
    {
        int numCasa;
        int dpi;
        decimal cuota;

        public int NumCasa { get => numCasa; set => numCasa = value; }
        public int Dpi { get => dpi; set => dpi = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
    }
}
