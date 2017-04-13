﻿using System;
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


        public ReportView()
        {
            InitializeComponent();
        }

        internal void Form2_Load(object sender, EventArgs e)
        {
            Focus();
            int count = 0;
            lista = IOarchivos.ReadJsonList<Registro>(file);
            foreach (Registro reg in lista)
            {
                count++;
            }
            label1.Text = "hay un total de " + count + " registros";
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
            List<Registro> porfecha = new List<Registro>();
            //por fecha
            try
            {
                //lista = Form1.ReadFromBinaryFile<List<Registro>>(file);
                lista = IOarchivos.ReadJsonList<Registro>(file);
                foreach (Registro reg in lista)
                {
                    DateTime freg = DateTime.ParseExact(reg._fecha, "d", null);
                    if (freg >= dateTimePicker1.Value.Date && freg <= dateTimePicker2.Value.Date)
                    {
                        porfecha.Add(reg);
                    }

                }
                dgvRegistros.DataSource = null;
                dgvRegistros.DataSource = porfecha;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar /n" + ex.ToString());
            }

        }

        private void btnMostrarTodoClick(object sender, EventArgs e)
        {
            try
            {
                //lista = Form1.ReadFromBinaryFile<List<Registro>>(file);
                lista = IOarchivos.ReadJsonList<Registro>(file);
                dgvRegistros.DataSource = null;
                dgvRegistros.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar /n" + ex.ToString());
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
            foreach (Registro reg in lista)
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

            listareporte.Add(new Registro_Report() { variable = "Dosis Central", promedio = decimal.Round(DosisCentrales.Average(),2), max = DosisCentrales.Max(), fechamax = fechas[Array.IndexOf(DosisCentrales, DosisCentrales.Max())], min = DosisCentrales.Min(), fechamin = fechas[Array.IndexOf(DosisCentrales, DosisCentrales.Min())], vlb = lb.central });
            listareporte.Add(new Registro_Report() { variable = "Simetría Arriba-Abajo", promedio = decimal.Round(SimetriasArribaAbajo.Average(),2), max = SimetriasArribaAbajo.Max(), fechamax = fechas[Array.IndexOf(SimetriasArribaAbajo, SimetriasArribaAbajo.Max())], min = SimetriasArribaAbajo.Min(), fechamin = fechas[Array.IndexOf(SimetriasArribaAbajo, SimetriasArribaAbajo.Min())], vlb = lb.simetriaArribaAbajo });
            listareporte.Add(new Registro_Report() { variable = "Simetría Izquierda-Derecha", promedio = decimal.Round(SimetriasIzquierdaDerecha.Average(), 2), max = SimetriasIzquierdaDerecha.Max(), fechamax = fechas[Array.IndexOf(SimetriasIzquierdaDerecha, SimetriasIzquierdaDerecha.Max())], min = SimetriasIzquierdaDerecha.Min(), fechamin = fechas[Array.IndexOf(SimetriasIzquierdaDerecha, SimetriasIzquierdaDerecha.Min())], vlb = lb.simetriaIzquierdaDerecha });
            listareporte.Add(new Registro_Report() { variable = "Planicidad Arriba-Abajo", promedio = decimal.Round(PlanicidadesArribaAbajo.Average(), 2), max = PlanicidadesArribaAbajo.Max(), fechamax = fechas[Array.IndexOf(PlanicidadesArribaAbajo, PlanicidadesArribaAbajo.Max())], min = PlanicidadesArribaAbajo.Min(), fechamin = fechas[Array.IndexOf(PlanicidadesArribaAbajo, PlanicidadesArribaAbajo.Min())], vlb = lb.planicidadArribaAbajo });
            listareporte.Add(new Registro_Report() { variable = "Planicidad Arriba-Abajo", promedio = decimal.Round(PlanicidadesIzquierdaDerecha.Average(), 2), max = PlanicidadesIzquierdaDerecha.Max(), fechamax = fechas[Array.IndexOf(PlanicidadesIzquierdaDerecha, PlanicidadesIzquierdaDerecha.Max())], min = PlanicidadesIzquierdaDerecha.Min(), fechamin = fechas[Array.IndexOf(PlanicidadesIzquierdaDerecha, PlanicidadesIzquierdaDerecha.Min())], vlb = lb.planicidadIzquierdaDerecha });

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = listareporte;

        }

        private void btnXLS_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(DataTable));
            IOarchivos.CreateCSVFile(ref dt, "excel.csv");
            IOarchivos.WriteJson("desdecsv.bin",JsonConvert.SerializeObject(File.ReadAllText("excel.csv")));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins();

            int anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            int altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            Metodos.imprimirTitulo(e, "Titulo", anchoTotal, 0);
            Metodos.imprimirTexto(e, "prueba\nprueba \n \n casa", anchoTotal, 50, 4);
            Metodos.imprimirGrafico(e, chart1, anchoTotal, 150);
            Metodos.imprimirtabla(e, dgvReportes, anchoTotal, 550);
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            ChartArea area = new ChartArea();
            Series serie1 = new Series();
            serie1.Name = "Dosis Centrales";
            serie1.Points.DataBindXY(fechas, DosisCentrales);
            serie1.ChartType = SeriesChartType.Line;

            Series serie2 = new Series();
            serie2.Name = "Linea Base";
            serie2.Points.DataBindXY(fechas, lineabasecentral);
            serie2.ChartType = SeriesChartType.Line;

            Series serie3 = new Series();
            serie3.Name = "Tolerancia +";
            serie3.Points.DataBindXY(fechas, toleranciamas);
            serie3.ChartType = SeriesChartType.Line;

            Series serie4 = new Series();
            serie4.Name = "Tolerancia -";
            serie4.Points.DataBindXY(fechas, toleranciamenos);
            serie4.ChartType = SeriesChartType.Line;
            

            chart1.Series.Clear(); chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(area);
            chart1.Series.Add(serie1);
            chart1.Series.Add(serie2);
            chart1.Series.Add(serie3);
            chart1.Series.Add(serie4);

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