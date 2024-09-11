using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Sesione
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string? Token { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaUltimaActividad { get; set; }

    public bool? Activo { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
