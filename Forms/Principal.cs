using System;
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

        private void lecturas_Leave(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            tb.Text = tb.Text.Replace(".", ",");
            if (String.IsNullOrEmpty(tb.Text))
            {
                if (tb.Tag != null)
                {
                    tb.Text = tb.Tag.ToString();
                    tb.ForeColor = Color.Gray;
                }
            }
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
    }
}
