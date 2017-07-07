using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Controles2016
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //cambio de cultura para usar el . como separador decimal.
            CultureInfo current = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                //MessageBox.Show("The current delimiter is : "+ current.NumberFormat.NumberDecimalSeparator);
            current.NumberFormat.NumberDecimalSeparator = ",";
            //   MessageBox.Show("The current delimiter is : "+ current.NumberFormat.NumberDecimalSeparator);
            Thread.CurrentThread.CurrentCulture = current;
            Thread.CurrentThread.CurrentUICulture = current;
            Application.Run(new Form1());
        }
    }
}
