using System;

namespace Controles2016
{
    [Serializable]
    internal class LecturaTracker
    {

        public LecturaTracker(decimal lecturaPresion, decimal lecturaTemperatura, decimal lecturaCentral, decimal lecturaArriba, decimal lecturaAbajo, decimal lecturaIzquierda, decimal lecturaDerecha)
        {
            _lecturaPresion = lecturaPresion;
            _lecturaTemperatura = lecturaTemperatura;
            _lecturaCentral = lecturaCentral;
            _lecturaArriba = lecturaArriba;
            _lecturaAbajo = lecturaAbajo;
            _lecturaIzquierda = lecturaIzquierda;
            _lecturaDerecha = lecturaDerecha;
        }

        decimal _lecturaPresion { get; set; }
        decimal _lecturaTemperatura { get; set; }
        decimal _lecturaCentral { get; set; }
        decimal _lecturaArriba { get; set; }
        decimal _lecturaAbajo { get; set; }
        decimal _lecturaIzquierda { get; set; }
        decimal _lecturaDerecha { get; set; }
    }
}