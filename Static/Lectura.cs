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
            if (ingresado == null) throw new ArgumentNullException(nameof(ingresado));
            return Decimal.Parse(ingresado, CultureInfo.CurrentCulture);
        }
    }
}
