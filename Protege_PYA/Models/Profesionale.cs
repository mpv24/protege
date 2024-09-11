using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Profesionale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Especialidad { get; set; }

    public string? Informacion { get; set; }

    public byte[]? Imagen { get; set; }

    public string? ImagenMimeType { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; } // Relación con Usuario

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
