using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Mensaje
{
    public int Id { get; set; }

    public int? ConversacionId { get; set; }

    public int? RemitenteId { get; set; }

    public string? Mensaje1 { get; set; }

    public string? FechaEnvio { get; set; }

    public bool? Leido { get; set; }

    public virtual Conversacione? Conversacion { get; set; }

    public virtual Usuario? Remitente { get; set; }
}
