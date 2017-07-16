using System;

namespace Controles2016
{
    [Serializable]
    public class ControlSeguridad
    {
        bool _switchPuerta { get; set; }
        bool _lucesPuerta { get; set; }
        bool _luzConsola { get; set; }
        bool _apagadoEmergencia { get; set; }
    }
}