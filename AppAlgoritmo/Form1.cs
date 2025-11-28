using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAlgoritmo
{
    public partial class Form1 : Form
    {
        private int[] datos;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Aqui realice el algoritmo para que al dar click en el boton Generar se generen los numeros aleatorios
        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            int n;

            if (!int.TryParse(txtCantidad.Text, out n))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            lstDatos.Items.Clear();
            lstOrdenada.Items.Clear();

            txtCantidad.Text = "Registros: 0";

            await Task.Run(() =>
            {
                Random r = new Random();
                datos = new int[n];
                for (int i = 0; i < n; i++)
                {
                    datos[i] = r.Next(1, n);
                }
            });

                foreach (var num in datos.Take(5000))
                lstDatos.Items.Add(num.ToString());

            txtCantidad.Text = $"Registros: {datos.Length}";
            MessageBox.Show("Datos Generados");
           
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {

        }
    }
}
