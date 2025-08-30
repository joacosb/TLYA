# Teoría de los Lenguajes y Algoritmos — Sistema de Notas (WinForms)
## Hola, alumnos

Este proyecto les da una base navegable en WinForms para enfocarse en lógica, POO (programación orientada a objetos) y validaciones. La idea es que completen y mejoren la lógica para cumplir la consigna y practicar lo visto en clase (y lo que verán en Construcción de Aplicaciones Informáticas). 💪

## Tecnologías

.NET / C# (Windows Forms)

Patrón simple de Modelos + Servicio de dominio + Formularios (UI)

Cómo ejecutar

Abrí la solución en Visual Studio.

Ejecutá (F5).

Flujo: Setup inicial (Fechas → Alumnos) → Menú principal → Submenús 1/2/3.

## Estructura del proyecto

/ (raíz)
├─ Models/
│ └─ Alumno.cs
├─ Services/
│ └─ CursadaService.cs
├─ Forms (los nombres pueden variar según tu repo)
│ ├─ SetupInicialForm.cs (+ .Designer.cs/.resx) ← o SetUpInicialForm.cs
│ ├─ MenuPrincipalForm.cs (+ .Designer.cs/.resx)
│ ├─ Submenu1Form.cs (+ .Designer.cs/.resx)
│ ├─ Submenu2Form.cs (+ .Designer.cs/.resx)
│ └─ Submenu3Form.cs (+ .Designer.cs/.resx)
├─ Program.cs
└─ README.md

Los formularios son partial: el .Designer.cs contiene controles e InitializeComponent(); el .cs tiene la lógica (eventos, llamadas al servicio, validaciones de UI).

## Flujo de la aplicación

Program.cs crea una única instancia de CursadaService (estado compartido).

Se abre SetupInicialForm (pestañas):
• Fechas: Examen 1/2/3 + Recuperatorio (dd/mm) en orden creciente.
• Alumnos: alta/edición/borrado con validaciones y grilla para visualizar.

Si el setup finaliza en OK, se abre MenuPrincipalForm.

Desde el menú se navega a Submenú 1, Submenú 2 y Submenú 3.

## Modelo de datos (Objetos)
### Alumno

Responsabilidad: representar un alumno y sus calificaciones.

Atributos principales (típicos):

Nombre : string (no vacío)

Apellido : string (no vacío)

Registro : int (100000–999999, único)

Notas : List<int> (3 parciales en 0..10)

#### Derivados (calculados):

Promedio : double

Condicion : string

SituacionFinal : string

## Reglas:

Un alumno es AUSENTE cuando Promedio == 0.

Registro dentro de rango y sin duplicados.

Notas dentro de 0..10.

Encapsulamiento: se recomienda calcular Promedio/Condicion/Situacion desde el servicio o un método del modelo para mantener coherencia.

## Servicio de dominio
### CursadaService

Responsabilidad: orquestar reglas, mantener el estado y ofrecer operaciones a la UI.

Estado:
- Alumnos : List<Alumno>
- FechasExamenesYRecuperatorios : List<DateTime> (Ex1, Ex2, Ex3, Recuperatorio)
Operaciones típicas:
Setup
SetFechasExamenesYRecuperatorios(List<DateTime>)
ABM
AgregarAlumno(Alumno, out string? error)
Editar(int registro, string nombre, string apellido, List<int> notas, out string? error)
Borrar(int registro)
Buscar(int registro) : Alumno?

Consultas:
Ausentes() — Insuficientes() — Regularizados()
PorCondicionCursada() — PorSituacionFinal()
ModaNotas() : (int nota, int repeticiones, int alumnosUnicos)

Utilidades:
OrdenarPorRegistro() — UnificarDatos()

Composición: el servicio compone alumnos y concentra las reglas.
Inyección simple: la misma instancia se pasa a todas las pantallas para que vean el mismo estado.

## Formularios (UI y eventos)
SetupInicialForm (o SetUpInicialForm)

Fechas: valida formato dd/mm y orden creciente (Ex1 < Ex2 < Ex3 < Recuperatorio).

Alumnos: entradas + DataGridView. Eventos: Agregar, Editar, Borrar, Finalizar.

Al Finalizar devuelve DialogResult.OK y se abre el menú.

MenuPrincipalForm

Pantalla de navegación. Abre Submenús 1/2/3 con la misma instancia de CursadaService.

Submenu1Form

Listados (Ausentes, Insuficientes, Listado completo, Notas, Regularizados).

Implementación simple: salida ordenada en TextBox monoespaciado (o DataGridView si se desea).

Submenu2Form

Consulta de Fechas (ya no se cargan aquí), conteos por Condición y por Situación, Promedios por alumno, Borrar por registro.

Submenu3Form

Buscar / Editar alumno, Moda de notas, Ordenar por registro, Unificar duplicados.

## Validaciones (qué y dónde)

Fechas: dd/mm y orden creciente (setup).

Alumno:
• Nombre/Apellido no vacíos → validación en UI y/o servicio.
• Registro en rango y único → servicio.
• Notas en 0..10 → UI y/o servicio.

Estado derivado:
• Promedio y AUSENTE cuando Promedio == 0.
• Otras categorías (INSUFICIENTE/REGULARIZADO/APROBADO) según reglas de cátedra.

Buena práctica: centralizar reglas de negocio en el servicio evita duplicación entre pantallas.

## Teoría aplicada (mini-snippets didácticos)
Decisión (if / switch)

Registro válido
if (registro < 100000 || registro > 999999)
{
error = "Registro fuera de rango (100000..999999)";
return false;
}

Situación final (ejemplo)
string SituacionDe(double prom) => prom switch
{
0 => "AUSENTE",
< 4.0 => "INSUFICIENTE",
< 7.0 => "REGULARIZADO",
_ => "APROBADO"
};

Repetición (for / foreach / while)

Recorrer alumnos
foreach (var a in Alumnos)
Console.WriteLine($"{a.Registro} - {a.Apellido}, {a.Nombre}: {a.Promedio:0.##}");

Cargar 4 fechas válidas con reintentos
for (int i = 0; i < 4; i++)
{
bool ok = false;
while (!ok)
{
var s = Pedir("Fecha (dd/mm): ");
ok = TryParseDiaMes(s, out var _);
}
}

## Funciones vs. Procedimientos

Función (devuelve valor, idealmente pura)
double PromedioDe(List<int> notas) => notas.Count == 0 ? 0 : notas.Average();

Procedimiento (cambia estado)
void OrdenarPorRegistro() => Alumnos.Sort((a, b) => a.Registro.CompareTo(b.Registro));

POO (encapsulamiento, herencia, polimorfismo)

Encapsulamiento: Forms piden al servicio agregar/editar/borrar; no manipulan la lista “a mano”.

Herencia: todos los formularios heredan de Form.

Polimorfismo (delegados de eventos): múltiples handlers compatibles con EventHandler
btnBuscar.Click += btnBuscar_Click; // (object, EventArgs)
btnEditar.Click += btnEditar_Click;
btnBorrar.Click += btnBorrar_Click;

## Interacción entre componentes

[Program] → (CursadaService compartido)
├─ SetupInicialForm (Fechas + ABM Alumnos)
└─ MenuPrincipalForm
├─ Submenu1Form (listados)
├─ Submenu2Form (estadísticas/consultas)
└─ Submenu3Form (gestión puntual)

## Ideas para extender
Persistencia: Guardar/Cargar en JSON/CSV.
Enums para Condicion y SituacionFinal.
Interfaces (p. ej. ICriterioAprobacion) para estrategias alternativas de promoción (polimorfismo real).
Reportes: top N promedios, histograma de notas, etc.

Tests unitarios de la lógica de CursadaService.
