using System;

namespace Controles2016
{
    [Serializable]
    internal class ControlMecanico
    {
        public ControlMecanico(bool laser, bool distancia, bool cincox, bool diezx, bool veinticincox, bool mlc)
        {
            this.laser = laser;
            this.distancia = distancia;
            this.cincox = cincox;
            this.diezx = diezx;
            this.veinticincox = veinticincox;
            this.mlc = mlc;
        }

        bool laser { get; set; }
        bool distancia { get; set; }
        bool cincox { get; set; }
        bool diezx { get; set; }
        bool veinticincox { get; set; }
        bool mlc { get; set; }
    }
}