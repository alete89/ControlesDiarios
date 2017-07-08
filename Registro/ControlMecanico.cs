using System;

namespace Controles2016
{
    [Serializable]
    internal class ControlMecanico
    {
        public ControlMecanico(bool laser, bool distancia, bool cincox, bool diezx, bool veinticincox, bool mlc)
        {
            _laser = laser;
            _distancia = distancia;
            _cincox = cincox;
            _diezx = diezx;
            _veinticincox = veinticincox;
            _mlc = mlc;
        }

        bool _laser { get; set; }
        bool _distancia { get; set; }
        bool _cincox { get; set; }
        bool _diezx { get; set; }
        bool _veinticincox { get; set; }
        bool _mlc { get; set; }
    }
}