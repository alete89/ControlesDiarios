using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Statistics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace PruebaUI.Metodos
{
    static class MGraficos
    {

        public static void graficarperfil(string nombre, string titulo, Vector<double> Eje, Vector<double> Perfil, Chart Grafico, double Tam)
        {
            FontFamily fuente = new FontFamily("Segoe UI");
            Grafico.Titles.Clear(); Grafico.ChartAreas.Clear(); Grafico.Series.Clear();
            ChartArea Area = new ChartArea(); Grafico.ChartAreas.Add(Area);
            Area.AxisX.Title = "posición [cm]";
            Area.AxisX.Minimum = Math.Round(-Tam * 0.7, 0);
            Area.AxisX.Maximum = Math.Round(Tam * 0.7, 0);
            Area.AxisX.LineColor = System.Drawing.Color.Black;
            Area.AxisX.MajorGrid.Interval = 1;
            Area.AxisX.MajorTickMark.Interval = 1;
            Area.AxisX.LabelStyle.Interval = 1;
            Area.AxisX.IsLabelAutoFit = false;
            Area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);
            //Area.AxisY.Title = "unidades relativas";
            Area.AxisY.Minimum = 0;
            Area.AxisY.Maximum = 110;
            Area.AxisY.LineColor = System.Drawing.Color.Black;
            Area.AxisY.MajorGrid.Interval = 20;
            Area.AxisY.MajorTickMark.Interval = 20;
            Area.AxisY.LabelStyle.Interval = 20;
            Area.AxisY.IsLabelAutoFit = false;
            Area.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);

            Series serie1 = new Series(); Grafico.Series.Add(serie1);
            serie1.Points.DataBindXY(Eje, Perfil);
            serie1.ChartType = SeriesChartType.FastPoint;
            serie1.MarkerColor = System.Drawing.Color.Blue;
            serie1.MarkerSize = 4;
            serie1.MarkerStyle = MarkerStyle.Circle;
            serie1.ToolTip = "#VALY \n #VALX cm";
            serie1.IsVisibleInLegend = false;

            Grafico.Titles.Add(titulo);

            Grafico.Titles[0].Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Regular);

            Grafico.Visible = true;
        }
        public static void graficarregistros(string nombre, string[] Fecha, double[] Variable, double LBValor, Chart Grafico, double Tol)
        {
            if (nombre == "Dosis Central") { Tol = Tol * LBValor / 100; }
            FontFamily fuente = new FontFamily("Segoe UI");
            double[] dFecha = new double[Fecha.Count()];
            DateTime[] DTFecha = new DateTime[Fecha.Count()];

            for (int i = 0; i < Fecha.Count(); i++)
            {
                DTFecha[i] = Convert.ToDateTime(Fecha[i], System.Globalization.CultureInfo.InvariantCulture);
                dFecha[i] = DTFecha[i].ToOADate();
            }

            Grafico.Titles.Clear(); Grafico.ChartAreas.Clear(); Grafico.Series.Clear(); Grafico.Legends.Clear();
            ChartArea Area = new ChartArea(); Grafico.ChartAreas.Add(Area);

            double Xmin; double Xmax;
            if (dFecha.Min() == dFecha.Max()) { Xmin = dFecha.Min() * 0.95; Xmax = dFecha.Min() * 1.05; }
            else { Xmin = dFecha.Min(); Xmax = dFecha.Max(); }
            double Ymin = Math.Min(Variable.Min(), LBValor-Tol); double Ymax = Math.Max(Variable.Max(), LBValor+Tol);

            Area.AxisX.Minimum = Xmin - (Xmax - Xmin) / 10;
            Area.AxisX.Maximum = Xmax + (Xmax - Xmin) / 10;
            Area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);
            Area.AxisX.LineColor = System.Drawing.Color.Black;
            Area.AxisX.MajorGrid.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.MajorTickMark.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.LabelStyle.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.LabelStyle.Angle = 45;
            Area.AxisX.IsLabelAutoFit = false;
            Area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);
            Area.AxisY.Minimum = Ymin - (Ymax - Ymin) / 10;
            Area.AxisY.Maximum = Ymax + (Ymax - Ymin) / 10;
            Area.AxisY.LineColor = System.Drawing.Color.Black;
            Area.AxisY.IsLabelAutoFit = false;
            Area.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);
            Area.AxisY.LabelStyle.Format = "F3";

            Series Serievariable = new Series(); Grafico.Series.Add(Serievariable);
            Serievariable.Points.DataBindXY(DTFecha, Variable);
            Serievariable.ChartType = SeriesChartType.Point;
            Serievariable.MarkerColor = System.Drawing.Color.Blue;
            Serievariable.MarkerSize = 8;
            Serievariable.MarkerStyle = MarkerStyle.Circle;
            Serievariable.ToolTip = "#VALY \n #VALX";
            Serievariable.LegendText = nombre;
            Serievariable.IsVisibleInLegend = true;

            Series SerieLB = new Series(); Grafico.Series.Add(SerieLB);
            double[] LBarray = Enumerable.Repeat(LBValor, Variable.Count()).ToArray();
            SerieLB.Points.DataBindXY(DTFecha, LBarray);
            SerieLB.ChartType = SeriesChartType.Line;
            SerieLB.MarkerColor = Color.Orange;
            SerieLB.LegendText = "Linea Base";
            SerieLB.IsVisibleInLegend = true;

            Series SerieMTol = new Series(); Grafico.Series.Add(SerieMTol);
            double[] MTolarray = Enumerable.Repeat(LBValor+Tol, Variable.Count()).ToArray();
            SerieMTol.Points.DataBindXY(DTFecha, MTolarray);
            SerieMTol.ChartType = SeriesChartType.Line;
            SerieMTol.Color = Color.Gray;
            SerieMTol.BorderDashStyle = ChartDashStyle.Dash;
            SerieMTol.LegendText = "LB+Tol";
            SerieMTol.IsVisibleInLegend = true;

            Series SeriemTol = new Series(); Grafico.Series.Add(SeriemTol);
            double[] mTolarray = Enumerable.Repeat(LBValor-Tol, Variable.Count()).ToArray();
            SeriemTol.Points.DataBindXY(DTFecha, mTolarray);
            SeriemTol.ChartType = SeriesChartType.Line;
            SeriemTol.Color = Color.Gray;
            SeriemTol.BorderDashStyle = ChartDashStyle.Dot;
            SeriemTol.LegendText = "LB-Tol";
            SeriemTol.IsVisibleInLegend = true;


            Grafico.Titles.Add(nombre);
            Grafico.Titles[0].Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Regular);
            Grafico.Visible = true;
            Legend leyenda = new Legend(); Grafico.Legends.Add(leyenda);
            leyenda.Docking = Docking.Bottom;
            leyenda.Alignment = StringAlignment.Center;


        }
        public static void animareje(Axis eje, double valorMinInicial, double valorMinFinal, double valorMaxInicial, double valorMaxFinal, int paso, Chart grafico)
        {
            for (int i=0;i<paso;i++)
            {
                eje.Minimum += (valorMinFinal - valorMinInicial) / (paso - 1);
                eje.Maximum += (valorMaxFinal - valorMaxInicial) / (paso - 1);
                grafico.Update();
                System.Threading.Thread.Sleep(20);
            }
                
        }
    }
}
