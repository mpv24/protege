﻿using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Actividade
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public string? Url { get; set; }
}
