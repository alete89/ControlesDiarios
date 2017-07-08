using System;

namespace Controles2016
{
    [Serializable]
    internal class ControlMecanico
    {
        bool _laser { get; set; }
        bool _distancia { get; set; }
        bool _cincox { get; set; }
        bool _diezx { get; set; }
        bool _veinticincox { get; set; }
        bool _mlc { get; set; }
    }
}