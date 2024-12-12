using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Evento
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Titulo { get; set; }

    public int? UsuarioId { get; set; }

    public int? ProfesionalId { get; set; }

    public virtual Profesionale? Profesional { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
