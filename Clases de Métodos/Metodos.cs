using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace Controles2016
{

    public static class Metodos
    {

        public static void imprimirTitulo(PrintPageEventArgs e, string titulo, int anchohoja, int posicionlinea)
        {
            Font fuentetitulo = new Font("Arial", 30, FontStyle.Bold);
            StringFormat centro = new StringFormat(); centro.Alignment = StringAlignment.Center;
            SolidBrush color = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(0, posicionlinea, anchohoja, posicionlinea);
            e.Graphics.DrawString(titulo, fuentetitulo, color, rect, centro);
        }
        public static void imprimirTexto(PrintPageEventArgs e, string texto, int anchohoja, int posicionlinea, int numlineas)
        {
            Font fuentetexto = new Font("Arial", 12, FontStyle.Regular);
            StringFormat izquierda = new StringFormat(); izquierda.Alignment = StringAlignment.Near;
            SolidBrush color = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(0, posicionlinea, anchohoja, posicionlinea*numlineas);
            e.Graphics.DrawString(texto, fuentetexto, color, rect, izquierda);
        }
        public static void imprimirGrafico(PrintPageEventArgs e, Chart grafico, int anchohoja, int posicionlinea)
        {
            Rectangle rect = new Rectangle((anchohoja - grafico.Width) / 2, posicionlinea, grafico.Width, grafico.Height);
            grafico.Printing.PrintPaint(e.Graphics, rect);
        }

        public static void imprimirGraficoChico(PrintPageEventArgs e, Chart grafico, int x, int y, int ancho, int alto)
        {
            Rectangle rect = new Rectangle(x, y, ancho, alto);
            grafico.Printing.PrintPaint(e.Graphics, rect);
        }

        public static void imprimirtabla(PrintPageEventArgs e, DataGridView tabla, int anchohoja, int posicionlinea)
        {
            int x_value = (anchohoja-tabla.Width)/2;
            int y_value = posicionlinea;
            Font Header = new Font("Arial", 10, FontStyle.Bold);
            Font celda = new Font("Arial", 9, FontStyle.Regular);
            StringFormat centro = new StringFormat(); centro.Alignment = StringAlignment.Center;
            StringFormat izquierda = new StringFormat(); izquierda.Alignment = StringAlignment.Near;
            SolidBrush color = new SolidBrush(Color.Black);


            foreach (DataGridViewColumn dc in tabla.Columns)
            {
                e.Graphics.DrawString(dc.HeaderText, Header, color, x_value, y_value,centro);
                x_value += dc.Width + 7;
            }
            y_value += 40;
            for (int i = 0; i < tabla.RowCount; i++)
            {
                
                DataGridViewRow dr = tabla.Rows[i];
                x_value = (anchohoja - tabla.Width) / 2;
                int j = 0;
                e.Graphics.DrawLine(Pens.Black, new Point(x_value-40, y_value), new Point(x_value+tabla.Width+200, y_value));
                foreach (DataGridViewColumn dc in tabla.Columns)
                {
                    string text = tabla[j,i].Value.ToString();
                    e.Graphics.DrawString(text, celda, color, x_value, y_value + 10f,centro);
                    x_value += dc.Width + 5;
                    j++;
                }
                y_value += 40;
            }
        }

    }
}

