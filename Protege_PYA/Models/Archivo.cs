using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Archivo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Url { get; set; }

    public string? Extension { get; set; }
}
