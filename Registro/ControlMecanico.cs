using System;
using System.Collections.Generic;

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

        public ControlMecanico(List<bool> lista)
        {
            this.mlc = lista[0];
            this.veinticincox = lista[1];
            this.diezx = lista[2];
            this.cincox = lista[3];
            this.distancia = lista[4];
            this.laser = lista[5];
        }

        public bool laser { get; set; }
        public bool distancia { get; set; }
        public bool cincox { get; set; }
        public bool diezx { get; set; }
        public bool veinticincox { get; set; }
        public bool mlc { get; set; }
    }
}