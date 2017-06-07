using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controles2016
{
    [Serializable]
    class Registro_Report
    {
        public string variable { get; set; }
        public decimal promedio { get; set; }
        public decimal max { get; set; }
        public string fechamax { get; set; }
        public decimal min { get; set; }
        public string fechamin { get; set; }
        public decimal LB { get; set; }

    }
}
