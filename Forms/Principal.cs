using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2016.Forms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void lecturas_Enter(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            if (tb.Text == tb.Tag.ToString())
            {
                tb.Text = String.Empty;
            }
            tb.ForeColor = Color.Black;
        }

        private void obsBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            if (String.IsNullOrEmpty(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gray;
            }
        }

        private void textbox_OnFocus(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            tb.SelectAll();
        }

        private LecturaTracker getLecturas()
        {
            return new LecturaTracker(Validar.lecturaDecimal(LecturaPresion.Text),
                                      Validar.lecturaDecimal(LecturaTemp.Text),
                                      Validar.lecturaDecimal(LecturaCentro.Text),
                                      Validar.lecturaDecimal(LecturaArriba.Text),
                                      Validar.lecturaDecimal(LecturaAbajo.Text),
                                      Validar.lecturaDecimal(LecturaIzquierda.Text),
                                      Validar.lecturaDecimal(LecturaDerecha.Text));
        }

        private ControlMecanico getMecanicos()
        {
            List<bool> lista = new List<bool>();
            foreach (Panel panel in Mecánicos.Controls)
            {
                try
                {
                    var seleccionado = panel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
                    if (seleccionado == "Correcto")
                    {
                        lista.Add(true);
                    }
                    else
                    {
                        lista.Add(false);
                    }
                }
                catch (Exception)
                {
                    lista.Add(false);
                }
            }
            return new ControlMecanico(lista);
        }

        private bool lecturasValidas()
        {
            return Validar.lecturaValida(LecturaPresion.Text) &&
                   Validar.lecturaValida(LecturaTemp.Text) &&
                   Validar.lecturaValida(LecturaCentro.Text) &&
                   Validar.lecturaValida(LecturaArriba.Text) &&
                   Validar.lecturaValida(LecturaAbajo.Text) &&
                   Validar.lecturaValida(LecturaIzquierda.Text) &&
                   Validar.lecturaValida(LecturaDerecha.Text);
        }

        private void nuevoRegistro_Click(object sender, EventArgs e)
        {
            LecturaTracker lecturas;
            if (lecturasValidas())
            {
                lecturas = getLecturas();
                Registro nuevoRegistro = new Registro(dateTimePicker1.Text, Responsable.Text, obsBox.Text, lecturas, getMecanicos());
                IOarchivos.writeJson(@"nuevoregistr.txt", nuevoRegistro);
            }
            else
            {
                MessageBox.Show("algunas lecturas no son validas");
            }



        }
    }
}
