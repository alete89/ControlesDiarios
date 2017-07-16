﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void nuevoRegistro_Click(object sender, EventArgs e)
        {
            // ESTA INSTANCIA NO DEBERÍA ESTAR ACÁ:
            LecturaTracker unaLecturaTracker = new LecturaTracker(Lectura.validar(LecturaPresion.Text),
                                                                  Lectura.validar(LecturaTemp.Text),
                                                                  Lectura.validar(LecturaCentro.Text),
                                                                  Lectura.validar(LecturaArriba.Text),
                                                                  Lectura.validar(LecturaAbajo.Text),
                                                                  Lectura.validar(LecturaIzquierda.Text),
                                                                  Lectura.validar(LecturaDerecha.Text));
            ControlMecanico unControlMecanico = new ControlMecanico(true, true, true, true, true, true);
            Registro nuevoRegistro = new Registro(dateTimePicker1.Text, Realizo.Text, obsBox.Text, unaLecturaTracker, unControlMecanico);
            IOarchivos.writeJson(@"nuevoregistr.txt", nuevoRegistro);

        }
    }
}
