using System;

namespace Controles2016
{
    [Serializable]
    public class Registro
    {
        public Registro(string fecha, string autor, string comentario, LecturaTracker lectura, ControlMecanico mecanico)
        {
            this.fecha = fecha;
            this.autor = autor;
            this.comentario = comentario;
            this.lectura = lectura;
            this.mecanico = mecanico;
        }

        public string fecha { get; set; }
        public string autor { get; set; }
        public string comentario { get; set; }

        public LecturaTracker lectura { get; set; }
        public ControlMecanico mecanico { get; set; }
        //ControlSeguridad seguridad { get; set; }
        //ControlEquipo equipo { get; set; }
        //Calculado calculado { get; set; }
    }
}
