using System;

namespace Controles2016
{
    [Serializable]
    internal class ControlEquipo
    {
        string _nivelAgua { get; set; }
        string _presionAgua { get; set; }
        string _temperaturaAgua { get; set; }
        string _presionGas { get; set; }
        string _temperaturaChiller { get; set; }
    }
}