using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2016
{
    public class Validar
    {
        public static bool lecturaValida(string ingresado)
        {
            if (String.IsNullOrEmpty(ingresado)) return false;
            string conPunto = ingresado.Replace(".", ",");
            return (Decimal.TryParse(conPunto, out decimal decimalResult));
        }

        public static decimal lecturaDecimal(string ingresado)
        {
            string conPunto = ingresado.Replace(".", ",");
            var fullDecimal = Decimal.Parse(conPunto);
            return Decimal.Round(fullDecimal, 3);
        }
    }
}
