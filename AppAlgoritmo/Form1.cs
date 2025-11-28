using System;
using System.Diagnostics;
using System.Linq;
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

            // Suscribo handlers a los botones para que coincidan con los nombres del diseñador
            // (btnSelection y BtnMerge están definidos en Form1.Designer.cs)
            if (btnSelection != null)
                btnSelection.Click += btnSelectionSort_Click;
            if (BtnMerge != null)
                BtnMerge.Click += btnMergeSort_Click;
            // Aseguro que el botón de búsqueda interpolada también esté suscrito si hace falta
            if (btnInterpolada != null)
                btnInterpolada.Click += btnInterpolada_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Genera números aleatorios
        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (entero mayor que 0).");
                return;
            }

            lstDatos.Items.Clear();
            lstOrdenada.Items.Clear();

            // Muestra inicio y arranca el cronómetro
            var sw = Stopwatch.StartNew();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            await Task.Run(() =>
            {
                var r = new Random();
                datos = new int[n];
                for (int i = 0; i < n; i++)
                    datos[i] = r.Next(1, n + 1);
            });

            // Detengo cronómetro y actualizo labels
            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F4} segundos";

            foreach (var num in datos.Take(5000))
                lstDatos.Items.Add(num.ToString());

            txtCantidad.Text = $"Registros: {datos.Length}";
            MessageBox.Show("Datos Generados");
        }

        // Botón general Ordenar (mantengo por compatibilidad) - por defecto usa MergeSort
        private async void btnOrdenar_Click(object sender, EventArgs e)
        {
            await EjecutarMergeSort();
        }

        // Selection Sort handler (suscrito en constructor si el diseñador usa btnSelection)
        private async void btnSelectionSort_Click(object sender, EventArgs e)
        {
            if (datos == null)
            {
                MessageBox.Show("Primero genere los datos.");
                return;
            }

            int[] copia = (int[])datos.Clone();
            lstOrdenada.Items.Clear();

            var sw = Stopwatch.StartNew();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            await Task.Run(() => SelectionSort(copia));

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F4} segundos";

            foreach (var item in copia.Take(5000))
                lstOrdenada.Items.Add(item.ToString());

            MessageBox.Show("Selection Sort completado.");
        }

        // Merge Sort handler (suscrito en constructor si el diseñador usa BtnMerge)
        private async void btnMergeSort_Click(object sender, EventArgs e)
        {
            await EjecutarMergeSort();
        }

        private async Task EjecutarMergeSort()
        {
            if (datos == null)
            {
                MessageBox.Show("Primero genere los datos.");
                return;
            }

            int[] copia = (int[])datos.Clone();
            lstOrdenada.Items.Clear();

            var sw = Stopwatch.StartNew();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            int[] resultado = null;
            await Task.Run(() => { resultado = MergeSort(copia); });

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F4} segundos";

            foreach (var item in resultado.Take(5000))
                lstOrdenada.Items.Add(item.ToString());

            MessageBox.Show("Merge Sort completado.");
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
            if (arr == null || arr.Length <= 1)
                return arr ?? new int[0];

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

            while (i < izq.Length) resultado[k++] = izq[i++];
            while (j < der.Length) resultado[k++] = der[j++];

            return resultado;
        }

        // =======================
        //   JUMP SEARCH
        // =======================
        private async void btnJump_Click(object sender, EventArgs e)
        {
            if (datos == null)
            {
                MessageBox.Show("Primero genere los datos.");
                return; 
            }

            if (!int.TryParse(txtValorBuscar.Text, out int x))
            {
                MessageBox.Show("Ingrese un valor entero válido en 'Valor a buscar'.");
                return;
            }

            int[] sorted = (int[])datos.Clone();
            Array.Sort(sorted);

            var sw = Stopwatch.StartNew();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            int pos = -1;
            await Task.Run(() => { pos = JumpSearch(sorted, x); });

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F6} segundos";

            if (pos >= 0)
                MessageBox.Show($"Valor {x} encontrado en la posición {pos} (0-based) en el arreglo ordenado.");
            else
                MessageBox.Show($"Valor {x} no encontrado.");
        }

        private int JumpSearch(int[] arr, int x)
        {
            if (arr == null || arr.Length == 0) return -1;

            int n = arr.Length;
            int step = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;

            while (prev < n && arr[Math.Min(step, n) - 1] < x)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n) return -1;
            }

            while (prev < Math.Min(step, n) && arr[prev] < x) prev++;

            if (prev < n && arr[prev] == x) return prev;
            return -1;
        }

        // =======================
        //   INTERPOLATION SEARCH
        // =======================
        private async void btnInterpolada_Click(object sender, EventArgs e)
        {
            if (datos == null)
            {
                MessageBox.Show("Primero genere los datos.");
                return;
            }

            if (!int.TryParse(txtValorBuscar.Text, out int x))
            {
                MessageBox.Show("Ingrese un valor entero válido en 'Valor a buscar'.");
                return;
            }

            int[] sorted = (int[])datos.Clone();
            Array.Sort(sorted);

            var sw = Stopwatch.StartNew();
            lblInicio.Text = $"Tiempo de inicio: {DateTime.Now:HH:mm:ss}";

            int pos = -1;
            await Task.Run(() => { pos = InterpolationSearch(sorted, x); });

            sw.Stop();
            lblFin.Text = $"Tiempo de fin: {DateTime.Now:HH:mm:ss}";
            lblDuracion.Text = $"Duración: {sw.Elapsed.TotalSeconds:F6} segundos";

            if (pos >= 0)
                MessageBox.Show($"Valor {x} encontrado en la posición {pos} (0-based) en el arreglo ordenado.");
            else
                MessageBox.Show($"Valor {x} no encontrado.");
        }

        private int InterpolationSearch(int[] arr, int x)
        {
            if (arr == null || arr.Length == 0) return -1;

            int low = 0, high = arr.Length - 1;
            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                if (arr[low] == arr[high])
                    return arr[low] == x ? low : -1;

                int pos = low + (int)(((double)(high - low) / (arr[high] - arr[low])) * (x - arr[low]));
                if (pos < low || pos > high) return -1;

                if (arr[pos] == x) return pos;
                if (arr[pos] < x) low = pos + 1;
                else high = pos - 1;
            }

            return -1;
        }
    }
}




