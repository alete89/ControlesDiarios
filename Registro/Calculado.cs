using System;

namespace Controles2016
{
    [Serializable]
    internal class Calculado
    {
        decimal _lecturaCentralCorregida { get; set; }
        decimal _lecturaCentralLineaBase { get; set; }
        decimal _simetriaArribaAbajo { get; set; }
        decimal _simetriaArribaAbajoLineaBase { get; set; }
        decimal _simetriaIzquierdaDerecha { get; set; }
        decimal _simetriaIzquierdaDerechaLineaBase { get; set; }
        decimal _planicidadIzquierdaDerecha { get; set; }
        decimal _planicidadArribaAbajo { get; set; }
        decimal _planicidadArribaAbajoLineaBase { get; set; }
        decimal _planicidadIzquierdaDerechaLineaBase { get; set; }
    }
}