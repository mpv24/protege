using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Charla
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? LinkMeet { get; set; }

    public bool? Asistir { get; set; }
}
