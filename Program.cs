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

            CultureInfo current = (CultureInfo)CultureInfo.CurrentCulture.Clone();

            current.NumberFormat.NumberDecimalSeparator = ",";

            Thread.CurrentThread.CurrentCulture = current;
            Thread.CurrentThread.CurrentUICulture = current;

            Application.Run(new Forms.Principal());
        }
    }
}
