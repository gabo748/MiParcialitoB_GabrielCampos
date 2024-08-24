namespace MiParcialitoB.Models;

public class Curso
{
    public int CursoId { get; set; }
    public string NombreCurso { get; set; }

    // Relación con Inscripciones
    public ICollection<Inscripcion> Inscripciones { get; set; }
}