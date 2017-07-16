using System;

namespace Controles2016
{
    [Serializable]
    public class ControlMecanico
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

        public bool laser { get; set; }
        public bool distancia { get; set; }
        public bool cincox { get; set; }
        public bool diezx { get; set; }
        public bool veinticincox { get; set; }
        public bool mlc { get; set; }
    }
}