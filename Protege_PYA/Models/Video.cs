using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Video
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Url { get; set; }

    public DateOnly? FechaSubida { get; set; }
}
