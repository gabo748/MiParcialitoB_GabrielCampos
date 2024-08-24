namespace MiParcialitoB.Models;

public class Inscripcion
{
    public int EstudianteId { get; set; }
    public int CursoId { get; set; }

    // Navegación a Estudiante y Curso
    public Estudiante Estudiante { get; set; }
    public Curso Curso { get; set; }
}