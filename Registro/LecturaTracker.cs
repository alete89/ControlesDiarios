using System;

namespace Controles2016
{
    [Serializable]
    internal class LecturaTracker
    {
        decimal _lecturaPresion { get; set; }
        decimal _lecturaTemperatura { get; set; }
        decimal _lecturaCentral { get; set; }
        decimal _lecturaArriba { get; set; }
        decimal _lecturaAbajo { get; set; }
        decimal _lecturaIzquierda { get; set; }
        decimal _lecturaDerecha { get; set; }
    }
}