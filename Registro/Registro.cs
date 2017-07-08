using System;

namespace Controles2016
{
    [Serializable]
    class Registro
    {
        string fecha { get; set; }
        string autor { get; set; }
        string comentario { get; set; }

        LecturaTracker lectura { get; set; }
        ControlMecanico mecanico { get; set; }
        ControlSeguridad seguridad { get; set; }
        ControlEquipo equipo { get; set; }
        Calculado calculado { get; set; }
    }
}
