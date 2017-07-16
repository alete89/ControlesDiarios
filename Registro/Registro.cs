using System;

namespace Controles2016
{
    [Serializable]
    class Registro
    {
        public Registro(string fecha, string autor, string comentario, LecturaTracker lectura, ControlMecanico mecanico)
        {
            this.fecha = fecha;
            this.autor = autor;
            this.comentario = comentario;
            this.lectura = lectura;
            this.mecanico = mecanico;
        }

        string fecha { get; set; }
        string autor { get; set; }
        string comentario { get; set; }

        LecturaTracker lectura { get; set; }
        ControlMecanico mecanico { get; set; }
        //ControlSeguridad seguridad { get; set; }
        //ControlEquipo equipo { get; set; }
        //Calculado calculado { get; set; }
    }
}
