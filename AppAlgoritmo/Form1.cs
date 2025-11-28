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

        /*
         PSEUDOCODE / PLAN (in detail)
         - Provide a correct Jump Search implementation in a separate method:
             - Method signature: private int JumpSearch(int[] arr, int valor)
             - If arr is null or empty -> return -1
             - Compute n = arr.Length
             - Compute step = floor(sqrt(n))
             - Iterate blocks:
                 - while arr[min(step, n)-1] < valor:
                     - prev = step
                     - step += floor(sqrt(n))
                     - if prev >= n -> value not found -> return -1
             - Linear search from prev to min(step, n)-1:
                 - if arr[i] == valor -> return i
             - After loop return -1
         - Update btnJump_Click event handler:
             - Verify datos != null and not empty
             - Prompt user for the integer to search (InputBox)
             - Parse input to int; if parse fails -> show message and return
             - Make a sorted copy of datos (since Jump Search requires sorted array)
             - Call JumpSearch on the sorted copy
             - Show result in a MessageBox (index or not found)
         - Keep the rest of the class intact (Generate and Sort functions unchanged)
        */

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

            // Cambia según lo que quieras probar:
            // si lo que quieres es Selection Sort, no comentes la siguiente línea y comenta la de MergeSort
            copia = MergeSort(copia);

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F2} segundos";

            foreach (var n in copia.Take(5000))
                lstOrdenada.Items.Add(n.ToString());

            MessageBox.Show("Ordenamiento completado.");
        }


        //   realice el algoritmo de Selection Sort

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


        //  Aqui realice el algoritmo de Merge Sort

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

        // Implementación correcta de Jump Search como método separado
        private int JumpSearch(int[] arr, int valor)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int n = arr.Length;
            int paso = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;

            // aca identificamos el bloque donde puede estar el valor
            while (prev < n && arr[Math.Min(paso, n) - 1] < valor)
            {
                prev = paso;
                paso += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            // esto es una busqueda lineal en el bloque identificado
            for (int i = prev; i < Math.Min(paso, n); i++)
                if (arr[i] == valor)
                    return i;

            return -1;
        }
    }
}

