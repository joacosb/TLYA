# Teoría de los Lenguajes y Algoritmos — Sistema de Notas (WinForms)
## Hola, alumnos 👋

La idea de este proyecto es que ya tengan la navegación entre pantallas y la estructura base lista, para enfocarse en lógica, POO y validaciones.
Más adelante, en Construcción de Aplicaciones Informáticas, verán cómo escalar estas ideas.

## 🚀 Cómo corre el programa

Program.cs crea una única instancia del servicio CursadaService (estado compartido).

Abre SetupInicialForm (pestañas):

Fechas: examen 1/2/3 y recuperatorio (dd/mm) en orden creciente.

Alumnos: alta/edición/borrado; validaciones básicas; grilla con datos.

Si el setup termina en OK, se abre MenuPrincipalForm con el mismo servicio.

Desde el menú: Submenú 1/2/3 (consultas, estadísticas y utilidades).

## 🗂️ Estructura del proyecto
SistemaNotasTLYA/
├─ Models/
│  └─ Alumno.cs
├─ Services/
│  └─ CursadaService.cs
├─ Forms/
│  ├─ SetupInicialForm.cs      (+ .Designer.cs/.resx)
│  ├─ MenuPrincipalForm.cs     (+ ...)
│  ├─ Submenu1Form.cs          (+ ...)
│  ├─ Submenu2Form.cs          (+ ...)
│  └─ Submenu3Form.cs          (+ ...)
└─ Program.cs


Los formularios son partial: el .Designer.cs contiene los controles y InitializeComponent(). El .cs tiene la lógica y los eventos (Click, etc.).

## 🧱 Modelo de datos (Objetos)
Alumno (entidad del dominio)

Propiedades (ejemplo):

string Nombre, string Apellido

int Registro (100000–999999, único)

List<int> Notas (3 parciales, 0–10)

Derivadas: double Promedio, string Condicion, string SituacionFinal

Reglas:

Ausente ⇢ cuando el promedio es 0.

Nombre/Apellido no vacíos; Notas en rango; Registro válido y no repetido.

Responsabilidad: representa un alumno y sus calificaciones.

POO – Encapsulamiento: los datos y las invariantes del alumno se manipulan a través del servicio para mantener consistencia.

## 🧰 Servicio (capa de dominio)
CursadaService

Estado compartido:

List<Alumno> Alumnos

List<DateTime> FechasExamenesYRecuperatorios (Ex1, Ex2, Ex3, Recuperatorio)

Operaciones (resumen típico):

Setup: SetFechasExamenesYRecuperatorios(fechas)

ABM:

bool AgregarAlumno(Alumno a, out string? error)

bool Editar(int registro, string nombre, string apellido, List<int> notas, out string? error)

bool Borrar(int registro)

Alumno? Buscar(int registro)

Consultas:

IEnumerable<Alumno> Ausentes()

IEnumerable<Alumno> Insuficientes()

IEnumerable<Alumno> Regularizados()

Estadística:

PorCondicionCursada() → (cantidades/porcentajes)

PorSituacionFinal() → (cantidades/porcentajes)

ModaNotas() → (notaModa, repeticiones, alumnosUnicos)

Utilidades:

OrdenarPorRegistro()

UnificarDatos() (si hay registros duplicados, mantiene el primero)

POO – Composición: el servicio compone una lista de Alumno.
Herencia: los formularios heredan de Form.
Polimorfismo (práctico): todos los handlers de eventos siguen la misma firma object, EventArgs y apuntan a métodos distintos; también es lugar natural para agregar interfaces si diseñan estrategias (p. ej., distintos criterios de promoción).

## 🖼️ Formularios (UI y eventos)

SetupInicialForm

TabFechas: valida formato dd/mm y que Ex1 < Ex2 < Ex3 < Recup.

TabAlumnos: entradas, validaciones, ABM y DataGridView.

Bloquea navegar a “Alumnos” hasta que las fechas estén OK.

MenuPrincipalForm

Abre Submenús inyectando el mismo CursadaService.

Submenu1Form

Muestra listados (ausentes, insuficientes, etc.).

Implementación simple: salida en TextBox multiline con fuente monoespaciada/tabla.

Submenu2Form

Consulta fechas ya cargadas (no las edita), promedios y distribuciones, conteos por condición/situación, borrado por registro.

Submenu3Form

Buscar/ Editar alumno, Moda de notas, Ordenar por registro, Unificar duplicados.

Event-driven: el flujo se dispara por eventos de UI (Click, SelectionChanged, etc.). Los formularios no guardan estado global: delegan en CursadaService.

## ✅ Validaciones (dónde y por qué)

Fechas (Setup):

Formato dd/mm

Orden creciente: Ex1 < Ex2 < Ex3 < Recuperatorio

Alumno:

Nombre/Apellido no vacíos

Registro en rango y único

Notas en 0..10

Estado derivado:

Ausente ⇢ Promedio == 0

Otras categorías (Insuficiente/Regularizado/Aprobado) según reglas de cátedra

Centralizar las reglas en el Servicio evita que cada form invente sus propias condiciones.

## 🧩 Ejemplos de teoría (mini-snippets)
1) Estructuras de decisión (if/else, switch)
// validar registro
if (registro < 100000 || registro > 999999)
{
    error = "Registro fuera de rango (100000..999999)";
    return false;
}

// determinar situación final (ejemplo genérico)
string SituacionDe(double promedio) => promedio switch
{
    0       => "AUSENTE",
    < 4.0   => "INSUFICIENTE",
    < 7.0   => "REGULARIZADO",
    _       => "APROBADO"
};

2) Estructuras de repetición (for, foreach, while)
// recorrer alumnos y mostrar promedio
foreach (var a in Alumnos)
{
    Console.WriteLine($"{a.Registro} - {a.Apellido}, {a.Nombre}: {a.Promedio:0.##}");
}

// pedir 4 fechas válidas (muestra while con reintentos)
for (int i = 0; i < 4; i++)
{
    bool ok = false;
    while (!ok)
    {
        string s = Pedir("Fecha (dd/mm): ");
        ok = TryParseDiaMes(s, out var dt);
    }
}

3) Funciones vs. procedimientos
// función: devuelve un valor (pura en lo posible)
double PromedioDe(List<int> notas) => notas.Count == 0 ? 0 : notas.Average();

// procedimiento: cambia estado (efecto)
void OrdenarPorRegistro() => Alumnos.Sort((a, b) => a.Registro.CompareTo(b.Registro));

4) POO: encapsulamiento, herencia, polimorfismo

Encapsulamiento: CursadaService decide cómo se agregan/validan alumnos; los forms no manipulan la lista “a mano”.

Herencia: todos los formularios : Form.

Polimorfismo (simple y visible en WinForms):

// todos estos métodos son "polimórficos" bajo el mismo delegado EventHandler
btnBuscar.Click   += btnBuscar_Click;   // (object, EventArgs)
btnEditar.Click   += btnEditar_Click;   // (object, EventArgs)
btnBorrar.Click   += btnBorrar_Click;   // ...

## 🔄 Flujo de datos (quién habla con quién)

Forms ⇄ CursadaService ⇄ Models

Program crea una instancia de CursadaService y se la inyecta a todos los formularios (constructor).

Los Submenús leen/escriben a través del Servicio para ver siempre el mismo estado.

Diagrama textual:

[Program] ──crea──> (CursadaService)
   │                        ▲
   ├── SetupInicialForm ────┤ (carga fechas + ABM alumnos)
   └── MenuPrincipalForm ───┼──> Submenu1/2/3 (consultas y utilidades)

🧪 Ideas para extender (práctica sugerida)

Persistencia: Guardar/Cargar en JSON/CSV.

Enums para Condicion y SituacionFinal.

Interfaz ICriterioAprobacion con implementaciones alternativas (polimorfismo real).

Reportes: top N promedios, histograma de notas, etc.

Tests unitarios de lógica del servicio.

📦 Git / .gitignore (resumen)

Colocá un .gitignore en la raíz (donde está la .sln) para ignorar .vs/, bin/, obj/, etc. Ejemplo mínimo:

## Visual Studio
.vs/
*.user
*.rsuser
*.csproj.user

## Build
[Bb]in/
[Oo]bj/
[Dd]ebug/
[Rr]elease/
x64/
x86/
TestResults/

## 📚 Créditos

Proyecto docente para Teoría de los Lenguajes y Algoritmos.
Navegación y base de código pensadas para practicar POO, validaciones y estructuras de control en C# / WinForms.
