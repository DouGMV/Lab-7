using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Reporte
    {
        string nombre;
        string apellido;
        int numCasa;
        decimal cuota;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int NumCasa { get => numCasa; set => numCasa = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
    }
}
