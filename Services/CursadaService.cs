using System;
using System.Collections.Generic;
using System.Linq;
using SistemaNotasTLYA.Models;

namespace SistemaNotasTLYA.Services
{
    public class CursadaService
    {
        private readonly List<Alumno> _alumnos = new();
        public IReadOnlyList<Alumno> Alumnos => _alumnos;

        // 3 parciales -> 1 recuperatorio (mitad redondeo hacia abajo)
        public List<DateTime> FechasExamenesYRecuperatorios { get; private set; } = new();

        public bool AgregarAlumno(Alumno a, out string error)
        {
            error = "";
            if (_alumnos.Count >= 26) { error = "Máximo 26 alumnos."; return false; }
            if (a.Registro < 100000 || a.Registro > 999999) { error = "Registro fuera de rango (100000..999999)."; return false; }
            if (_alumnos.Any(x => x.Registro == a.Registro)) { error = "Registro duplicado."; return false; }
            a.Recalcular();
            _alumnos.Add(a);
            return true;
        }

        public Alumno? Buscar(int registro) => _alumnos.FirstOrDefault(a => a.Registro == registro);

        public bool Editar(int registro, string nombre, string apellido, List<int> notas, out string error)
        {
            error = "";
            var a = Buscar(registro);
            if (a == null) { error = "No existe ese registro."; return false; }
            if (notas.Count != 3 || notas.Any(n => n < 0 || n > 10)) { error = "Notas inválidas (3 valores 0..10)."; return false; }
            a.Nombre = nombre.Trim();
            a.Apellido = apellido.Trim();
            a.Notas = notas.ToList();
            a.Recalcular();
            return true;
        }

        public bool Borrar(int registro)
        {
            var a = Buscar(registro);
            if (a == null) return false;
            _alumnos.Remove(a);
            return true;
        }

        public void OrdenarPorRegistro() => _alumnos.Sort((x, y) => x.Registro.CompareTo(y.Registro));

        public void UnificarDatos() // mantiene el primero, elimina duplicados por registro
        {
            var vistos = new HashSet<int>();
            for (int i = 0; i < _alumnos.Count; i++)
            {
                if (!vistos.Add(_alumnos[i].Registro))
                {
                    _alumnos.RemoveAt(i);
                    i--;
                }
            }
        }

        public IEnumerable<Alumno> Ausentes() => _alumnos.Where(a => a.SituacionFinal == SituacionFinal.AUSENTE);
        public IEnumerable<Alumno> Insuficientes() => _alumnos.Where(a => a.SituacionFinal == SituacionFinal.INSUFICIENTE);
        public IEnumerable<Alumno> Regularizados() => _alumnos.Where(a => a.SituacionFinal == SituacionFinal.REGULARIZADO);

        public (int ausentes, int cursando, double pAusentes, double pCursando) PorCondicionCursada()
        {
            int total = _alumnos.Count;
            int aus = _alumnos.Count(a => a.Condicion == CondicionCursada.AUSENTE);
            int cur = total - aus;
            return (aus, cur, total == 0 ? 0 : aus * 100.0 / total, total == 0 ? 0 : cur * 100.0 / total);
        }

        public (int aus, int insu, int reg, int apr, double pAus, double pInsu, double pReg, double pApr) PorSituacionFinal()
        {
            int total = _alumnos.Count;
            int aus = _alumnos.Count(a => a.SituacionFinal == SituacionFinal.AUSENTE);
            int ins = _alumnos.Count(a => a.SituacionFinal == SituacionFinal.INSUFICIENTE);
            int reg = _alumnos.Count(a => a.SituacionFinal == SituacionFinal.REGULARIZADO);
            int apr = _alumnos.Count(a => a.SituacionFinal == SituacionFinal.APROBADO);
            double pct(int x) => total == 0 ? 0 : x * 100.0 / total;
            return (aus, ins, reg, apr, pct(aus), pct(ins), pct(reg), pct(apr));
        }

        public (int notaModa, int repeticiones, int alumnosUnicos) ModaNotas()
        {
            var todas = _alumnos.SelectMany(a => a.Notas).ToList();
            if (todas.Count == 0) return (0, 0, 0);

            var grupos = todas.GroupBy(n => n)
                              .Select(g => new { Nota = g.Key, C = g.Count() })
                              .OrderByDescending(g => g.C).ThenBy(g => g.Nota)
                              .ToList();
            int moda = grupos.First().Nota;
            int rep = grupos.First().C;
            int alumnosUnicos = _alumnos.Count(a => a.Notas.Contains(moda));
            return (moda, rep, alumnosUnicos);
        }

        public void SetFechasExamenesYRecuperatorios(List<DateTime> fechasOrdenadas)
        {
            FechasExamenesYRecuperatorios = fechasOrdenadas;
        }
    }
}
