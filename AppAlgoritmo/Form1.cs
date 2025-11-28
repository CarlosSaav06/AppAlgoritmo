using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            if (datos == null)
            {
                MessageBox.Show("Primero genere los datos.");
                return;
            }

            int[] copia = (int[])datos.Clone();
            lstOrdenada.Items.Clear();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            // SELECTION SORT ó MERGE SORT
            // Cambia según lo que quieras probar:
            // SelectionSort(copia);
            copia = MergeSort(copia);

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F2} segundos";

            foreach (var n in copia.Take(5000))
                lstOrdenada.Items.Add(n.ToString());

            MessageBox.Show("Ordenamiento completado.");
        }

        // =======================
        //   SELECTION SORT
        // =======================
        private void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min])
                        min = j;

                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }

        // =======================
        //      MERGE SORT
        // =======================
        private int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int mid = arr.Length / 2;
            int[] izq = arr.Take(mid).ToArray();
            int[] der = arr.Skip(mid).ToArray();

            izq = MergeSort(izq);
            der = MergeSort(der);

            return Merge(izq, der);
        }

        private int[] Merge(int[] izq, int[] der)
        {
            int[] resultado = new int[izq.Length + der.Length];
            int i = 0, j = 0, k = 0;

            while (i < izq.Length && j < der.Length)
            {
                if (izq[i] <= der[j])
                    resultado[k++] = izq[i++];
                else
                    resultado[k++] = der[j++];
            }

            while (i < izq.Length)
                resultado[k++] = izq[i++];

            while (j < der.Length)
                resultado[k++] = der[j++];

            return resultado;
        }
    }
}

