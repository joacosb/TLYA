using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaNotasTLYA.Models
{
    public class Alumno
    {
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public int Registro { get; set; } // 100000..999999
        public List<int> Notas { get; set; } = new List<int> { 0, 0, 0 }; // tres parciales (0..10)
        public double Promedio { get; private set; }
        public CondicionCursada Condicion { get; private set; }
        public SituacionFinal SituacionFinal { get; private set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public void Recalcular()
        {
            Promedio = Notas.Average();
            Condicion = (Math.Abs(Promedio) < 1e-9) ? CondicionCursada.AUSENTE : CondicionCursada.CURSANDO;

            if (Math.Abs(Promedio) < 1e-9) SituacionFinal = SituacionFinal.AUSENTE;       // promedio 0
            else if (Promedio < 4) SituacionFinal = SituacionFinal.INSUFICIENTE;  // <4
            else if (Promedio < 7) SituacionFinal = SituacionFinal.REGULARIZADO;  // [4,7)
            else SituacionFinal = SituacionFinal.APROBADO;      // >=7
        }
    }
}
