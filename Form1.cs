using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        List<Propietario> propietarios = new List<Propietario>();
        List<Propiedad> propiedades = new List<Propiedad>();
        List<Reporte> reportes = new List<Reporte>();

        public Form1()
        {
            InitializeComponent();
        }

        public void CargarPropietarios()
        {
            //Leer el archivo y cargarlo a la lista
            string fileName = "Propietarios.txt";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            while (reader.Peek() > -1)
            {
                //Leer los datos de un propietario
                Propietario propietario = new Propietario();
                propietario.Dpi = Convert.ToInt32(reader.ReadLine());
                propietario.Nombre = reader.ReadLine();
                propietario.Apellido = reader.ReadLine();

                //Guardar al propietario en la lista de propietarios
                propietarios.Add(propietario);
            }
            //Cerrar el archivo
            reader.Close();
        }

        public void CargarPropiedades()
        {
            //Leer el archivo y cargarlo a la lista
            string fileName = "Propiedades.txt";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            while (reader.Peek() > -1)
            {
                //Leer los datos de una propiedad
                Propiedad propiedad = new Propiedad();
                propiedad.NumCasa = Convert.ToInt32(reader.ReadLine());
                propiedad.Dpi = Convert.ToInt32(reader.ReadLine());
                propiedad.Cuota = Convert.ToDecimal(reader.ReadLine());

                //Guardar la propiedad en la lista de propiedades
                propiedades.Add(propiedad);
            }
            //Cerrar el archivo
            reader.Close();
        }

        private void buttonLeer_Click(object sender, EventArgs e)
        {
            //Ya deben estar llenas todas las listas
            reportes.Clear();
            //Recorre cada alquiler
            foreach (var propietario in propietarios)
            {
                //obtiene los datos de la propiedad
                Propiedad propiedad = propiedades.Find(c => c.Dpi == propietario.Dpi);

                //Meter todos los datos obtenidos a la lista reporte
                Reporte reporte = new Reporte();
                reporte.Nombre = propietario.Nombre;
                reporte.Apellido = propietario.Apellido;
                reporte.NumCasa = propiedad.NumCasa;
                reporte.Cuota = propiedad.Cuota;

                reportes.Add(reporte);
            }
            MostrarReporte();
        }

        public void MostrarReporte()
        {
            //Mostrar la lista de Reporte en el DataGridView
            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reportes;
            dataGridViewReporte.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargar los datos
            CargarPropiedades();
            CargarPropietarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ordenar de forma descendente
            reportes = reportes.OrderByDescending(p => p.Cuota).ToList();

            MostrarReporte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ordenar de forma ascendente
            reportes = reportes.OrderBy(p => p.Cuota).ToList();

            MostrarReporte();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ordenar de forma descendente y asignarlo a cuotasAltas
            var cuotasAltas = reportes.OrderByDescending(p => p.Cuota).ToList();

            //Tomar los primeros 3 de cuotasAltas y asignarlos a tresMasAltos
            var tresMasAltos = cuotasAltas.Take(3).ToList();

            dataGridViewReporte.DataSource = tresMasAltos;
            dataGridViewReporte.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Ordenar de forma ascendente y asignarlo a cuotasBajas
            var cuotasBajas = reportes.OrderBy(p => p.Cuota).ToList();

            //Tomar los primeros 3 de cuotasBajas y asignarlos a tresMasBajos
            var tresMasBajos = cuotasBajas.Take(3).ToList();

            dataGridViewReporte.DataSource = tresMasBajos;
            dataGridViewReporte.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Ordenar de forma descendente y asignarlo a cuotasAltas
            var cuotasAltas = reportes.OrderByDescending(p => p.Cuota).ToList();

            //Tomar el primer dato de cuotasAltas y asignarlo a cuotaMasAlta
            var cuotaMasAlta = cuotasAltas.Take(1).ToList();

            dataGridViewReporte.DataSource = cuotaMasAlta;
            dataGridViewReporte.Refresh();
        }
    }
}
