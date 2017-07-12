using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2016
{
    public class Lectura
    {
        public static decimal validar(string ingresado)
        {
            if (String.IsNullOrEmpty(ingresado)) MessageBox.Show("string es null o empty");
            string conPunto = ingresado.Replace(".", ",");
            if (Decimal.TryParse(conPunto, out decimal decimalResult))
            {
                return decimalResult;
            }
            throw new ArgumentException("error parseando", nameof(ingresado));
        }
    }
}
