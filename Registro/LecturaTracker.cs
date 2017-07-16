using System;

namespace Controles2016
{
    [Serializable]
    public class LecturaTracker
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

        public decimal lecturaPresion { get; set; }
        public decimal lecturaTemperatura { get; set; }
        public decimal lecturaCentral { get; set; }
        public decimal lecturaArriba { get; set; }
        public decimal lecturaAbajo { get; set; }
        public decimal lecturaIzquierda { get; set; }
        public decimal lecturaDerecha { get; set; }
    }
}