using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int? RolId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string? Documento { get; set; }

    public string? Usuario1 { get; set; }

    public string? Pass { get; set; }

    public bool? Estado { get; set; }

    public int? Intentos { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Conversacione> ConversacioneUsuario1s { get; set; } = new List<Conversacione>();

    public virtual ICollection<Conversacione> ConversacioneUsuario2s { get; set; } = new List<Conversacione>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Sesione> Sesiones { get; set; } = new List<Sesione>();
}
