using System;
using System.Windows.Forms;
/// <summary>
/// IMPLEMENTAR QUE SE GUARDE LA LÍNEA BASE DE ALGUNA MANERA
/// </summary>
namespace Controles2016
{
    public partial class LineaBaseEdit : Form
    {
        public static LineaBaseEdit instanciaForm2 = null;


        public LineaBaseEdit()
        {
            InitializeComponent();
        }

        public void LineaBaseEdit_Load(object sender, EventArgs e)
        {

            LBlecturaCentral.Text = Form1.lb.central.ToString();
            LBplanicidadAA.Text = Form1.lb.planicidadArribaAbajo.ToString();
            LBplanicidadID.Text = Form1.lb.planicidadIzquierdaDerecha.ToString();
            LBsimetriaAA.Text = Form1.lb.simetriaArribaAbajo.ToString();
            LBsimetriaID.Text = Form1.lb.simetriaIzquierdaDerecha.ToString();
            instanciaForm2 = this;

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.instancia.checkBox1.Checked = false;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            Form1.lb.central = Convert.ToDecimal(LBlecturaCentral.Text);
            Form1.lb.planicidadArribaAbajo = Convert.ToDecimal(LBplanicidadAA.Text);
            Form1.lb.planicidadIzquierdaDerecha = Convert.ToDecimal(LBplanicidadID.Text);
            Form1.lb.simetriaArribaAbajo = Convert.ToDecimal(LBsimetriaAA.Text);
            Form1.lb.simetriaIzquierdaDerecha = Convert.ToDecimal(LBsimetriaID.Text);
            IOarchivos.WriteJson(@".\LB.bin",Form1.lb);
            MessageBox.Show("Nueva línea base guardada en archivo.");
        }

    }
}
