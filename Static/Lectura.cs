using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Controles2016
{
    public class Lectura
    {
        public static decimal validar(string ingresado)
        {
            if (String.IsNullOrEmpty(ingresado)) throw new ArgumentNullException(nameof(ingresado));
            string conPunto = ingresado.Replace(".", ",");
            if (Decimal.TryParse(conPunto, out decimal decimalResult))
            {
                return decimalResult;
            }
            throw new ArgumentException("error parseando", nameof(ingresado));
        }
    }
}
