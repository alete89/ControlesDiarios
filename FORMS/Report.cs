using System;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;


namespace Controles2016
{
    public partial class ReportView : Form
    {
        static List<Registro> lista = IOarchivos.ReadJsonList<Registro>(file);
        static List<Registro> porfecha = new List<Registro>();

        public static LineaBase lb = JsonConvert.DeserializeObject<LineaBase>(File.ReadAllText(@".\LB.bin"));

        const string file = @".\REGISTROS.bin";


        //lista = IOarchivos.ReadJsonList<Registro>(file);
        string[] fechas = new string[lista.Count];
        decimal[] DosisCentrales = new decimal[lista.Count];
        decimal[] SimetriasArribaAbajo = new decimal[lista.Count];
        decimal[] SimetriasIzquierdaDerecha = new decimal[lista.Count];
        decimal[] PlanicidadesArribaAbajo = new decimal[lista.Count];
        decimal[] PlanicidadesIzquierdaDerecha = new decimal[lista.Count];
        decimal[] lineabasecentral = new decimal[lista.Count];
        decimal[] toleranciamas = new decimal[lista.Count];
        decimal[] toleranciamenos = new decimal[lista.Count];
        decimal[][] Variables;
        string[] etiquetas = { "Dosis Central", "Simetría Y", "Simetria X", "Planicidad Y", "Planicidad X" };
        decimal[] lbarray = { lb.central, lb.simetriaArribaAbajo, lb.simetriaIzquierdaDerecha, lb.planicidadArribaAbajo, lb.planicidadIzquierdaDerecha };


        public ReportView()
        {
            InitializeComponent();
        }

        internal void Form2_Load(object sender, EventArgs e)
        {
            Focus();
            lista = IOarchivos.ReadJsonList<Registro>(file);
            label1.Text = "hay un total de " + lista.Count() + " registros";
            Focus();
            BringToFront();
        }

        private void ReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  this.Hide();
            //  e.Cancel = true; // this cancels the close event.
        }

        private void btnPorFechaClick(object sender, EventArgs e)
        {

            //por fecha
            try
            {
                //lista = Form1.ReadFromBinaryFile<List<Registro>>(file);
                lista = IOarchivos.ReadJsonList<Registro>(file);
                porfecha.Clear();
                foreach (Registro reg in lista)
                {
                    DateTime freg = DateTime.ParseExact(reg._fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (freg >= dateTimePicker1.Value.Date && freg <= dateTimePicker2.Value.Date)
                    {
                        porfecha.Add(reg);
                    }
                }

                dgvRegistros.DataSource = null;
                dgvRegistros.DataSource = porfecha;
                btnPDF_Click(sender, e);
                btnGraficar_Click(sender, e);
                btnPDF.Enabled = true;
                btnGraficar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar \n" + ex.ToString());
            }

        }

        private void btnMostrarTodoClick(object sender, EventArgs e)
        {
            try
            {
                //lista = Form1.ReadFromBinaryFile<List<Registro>>(file);
                lista = IOarchivos.ReadJsonList<Registro>(file);
                porfecha.Clear();
                porfecha = lista;
                dgvRegistros.DataSource = null;
                dgvRegistros.DataSource = lista;
                btnPDF_Click(sender, e);
                btnGraficar_Click(sender, e);
                btnPDF.Enabled = true;
                btnGraficar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar \n" + ex.ToString());
            }

        }

        private void ReportView_Resize(object sender, EventArgs e)
        {
            //dgvRegistros.Width = Convert.ToInt16(ActiveForm.Width * 0.9);
            //dgvRegistros.Height = Convert.ToInt16(ActiveForm.Height * 0.7);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            int i = 0;
            Array.Resize(ref fechas, porfecha.Count());
            Array.Resize(ref DosisCentrales, porfecha.Count());
            Array.Resize(ref SimetriasArribaAbajo, porfecha.Count());
            Array.Resize(ref SimetriasIzquierdaDerecha, porfecha.Count());
            Array.Resize(ref PlanicidadesArribaAbajo, porfecha.Count());
            Array.Resize(ref PlanicidadesIzquierdaDerecha, porfecha.Count());
            Array.Resize(ref lineabasecentral, porfecha.Count());
            Array.Resize(ref toleranciamas, porfecha.Count());
            Array.Resize(ref toleranciamenos, porfecha.Count());
            foreach (Registro reg in porfecha)
            {
                fechas[i] = reg._fecha;
                DosisCentrales[i] = reg._lecturaCentralCorregida;
                SimetriasArribaAbajo[i] = reg._simetriaArribaAbajo;
                SimetriasIzquierdaDerecha[i] = reg._simetriaIzquierdaDerecha;
                PlanicidadesArribaAbajo[i] = reg._planicidadArribaAbajo;
                PlanicidadesIzquierdaDerecha[i] = reg._planicidadIzquierdaDerecha;
                lineabasecentral[i] = lb.central;
                toleranciamas[i] = lb.central * 1.03m;
                toleranciamenos[i] = lb.central * 0.97m;
                i++;
            }

            List<Registro_Report> listareporte = new List<Registro_Report>();

            listareporte.Add(new Registro_Report() { variable = "Dosis Central", promedio = decimal.Round(DosisCentrales.Average(), 2), max = decimal.Round(DosisCentrales.Max(),2), fechamax = fechas[Array.IndexOf(DosisCentrales, DosisCentrales.Max())], min = decimal.Round(DosisCentrales.Min(),2), fechamin = fechas[Array.IndexOf(DosisCentrales, DosisCentrales.Min())], LB = lb.central });
            listareporte.Add(new Registro_Report() { variable = "Simetría Y", promedio = decimal.Round(SimetriasArribaAbajo.Average(), 2), max = decimal.Round(SimetriasArribaAbajo.Max(),2), fechamax = fechas[Array.IndexOf(SimetriasArribaAbajo, SimetriasArribaAbajo.Max())], min = decimal.Round(SimetriasArribaAbajo.Min(),2), fechamin = fechas[Array.IndexOf(SimetriasArribaAbajo, SimetriasArribaAbajo.Min())], LB = lb.simetriaArribaAbajo });
            listareporte.Add(new Registro_Report() { variable = "Simetría X", promedio = decimal.Round(SimetriasIzquierdaDerecha.Average(), 2), max = decimal.Round(SimetriasIzquierdaDerecha.Max(),2), fechamax = fechas[Array.IndexOf(SimetriasIzquierdaDerecha, SimetriasIzquierdaDerecha.Max())], min = decimal.Round(SimetriasIzquierdaDerecha.Min(),2), fechamin = fechas[Array.IndexOf(SimetriasIzquierdaDerecha, SimetriasIzquierdaDerecha.Min())], LB = lb.simetriaIzquierdaDerecha });
            listareporte.Add(new Registro_Report() { variable = "Planicidad Y", promedio = decimal.Round(PlanicidadesArribaAbajo.Average(), 2), max = decimal.Round(PlanicidadesArribaAbajo.Max(),2), fechamax = fechas[Array.IndexOf(PlanicidadesArribaAbajo, PlanicidadesArribaAbajo.Max())], min = decimal.Round(PlanicidadesArribaAbajo.Min(), 2), fechamin = fechas[Array.IndexOf(PlanicidadesArribaAbajo, PlanicidadesArribaAbajo.Min())], LB = lb.planicidadArribaAbajo });
            listareporte.Add(new Registro_Report() { variable = "Planicidad X", promedio = decimal.Round(PlanicidadesIzquierdaDerecha.Average(), 2), max = decimal.Round(PlanicidadesIzquierdaDerecha.Max(),2), fechamax = fechas[Array.IndexOf(PlanicidadesIzquierdaDerecha, PlanicidadesIzquierdaDerecha.Max())], min = decimal.Round(PlanicidadesIzquierdaDerecha.Min(),2), fechamin = fechas[Array.IndexOf(PlanicidadesIzquierdaDerecha, PlanicidadesIzquierdaDerecha.Min())], LB = lb.planicidadIzquierdaDerecha });

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = listareporte;
            Variables = new[] { DosisCentrales, SimetriasArribaAbajo, SimetriasIzquierdaDerecha, PlanicidadesArribaAbajo, PlanicidadesIzquierdaDerecha };
        }

        private void btnXLS_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(DataTable));
            IOarchivos.CreateCSVFile(ref dt, "excel.csv");
            IOarchivos.WriteJson("desdecsv.bin", JsonConvert.SerializeObject(File.ReadAllText("excel.csv")));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(50,50,50,50);

            int anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            int altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            Metodos.imprimirTitulo(e, "Reporte controles diarios", anchoTotal, 0);
            Metodos.imprimirTexto(e, "Fecha inicial: " + fechas[0].ToString() + "\n" + "Fecha final: " + fechas[fechas.Count() - 1].ToString(), anchoTotal, 70, 4);
            Metodos.imprimirtabla(e, dgvReportes, anchoTotal, 160);

            int x = 170; int y = 400;

            MGraficos.graficarregistros(etiquetas[0], fechas, Variables[0], lbarray[0], chart1, 0.03m * lbarray[0]);
            chart1.Series[0].MarkerSize = 0;
            Metodos.imprimirGraficoChico(e, chart1, x, y, chart1.Width, Convert.ToInt32(chart1.Height/1.3));
            y += Convert.ToInt32(chart1.Height / 1.2);
            x = 20;
            for (int i=1;i<5;i++)
            {
                MGraficos.graficarregistros(etiquetas[i], fechas, Variables[i], lbarray[i], chart1, 3);
                chart1.Series[0].MarkerSize = 0;
                foreach(var serie in chart1.Series) { serie.IsVisibleInLegend = false; }
                Metodos.imprimirGraficoChico(e, chart1, x, y, Convert.ToInt32(chart1.Width/1.5), Convert.ToInt32(chart1.Height / 1.6));
                if (i%2!=0)
                {
                    x += 400;
                }
                else
                {
                    x = 20; y+= Convert.ToInt32(chart1.Height / 1.5);
                }
            }
            btnGraficar_Click(sender, e);
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (LB_VariableAGraficar.SelectedIndex==-1)
            { LB_VariableAGraficar.SelectedIndex = 0; }
            else {aux = LB_VariableAGraficar.SelectedIndex; }
            decimal tol;
            if (aux==0)
            {
                tol = 0.03m * lbarray[aux];
            }
            else { tol = 3; }
            MGraficos.graficarregistros(etiquetas[aux], fechas, Variables[aux], lbarray[aux], chart1, tol);
        }

        private void btnPDF_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

    }
}
