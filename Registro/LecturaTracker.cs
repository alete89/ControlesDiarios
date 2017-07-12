using System;

namespace Controles2016
{
    [Serializable]
    internal class LecturaTracker
    {

        public LecturaTracker(decimal lecturaPresion, decimal lecturaTemperatura, decimal lecturaCentral, decimal lecturaArriba, decimal lecturaAbajo, decimal lecturaIzquierda, decimal lecturaDerecha)
        {
            this.lecturaPresion = lecturaPresion;
            this.lecturaTemperatura = lecturaTemperatura;
            this.lecturaCentral = lecturaCentral;
            this.lecturaArriba = lecturaArriba;
            this.lecturaAbajo = lecturaAbajo;
            this.lecturaIzquierda = lecturaIzquierda;
            this.lecturaDerecha = lecturaDerecha;
        }

        decimal lecturaPresion { get; set; }
        decimal lecturaTemperatura { get; set; }
        decimal lecturaCentral { get; set; }
        decimal lecturaArriba { get; set; }
        decimal lecturaAbajo { get; set; }
        decimal lecturaIzquierda { get; set; }
        decimal lecturaDerecha { get; set; }
    }
}