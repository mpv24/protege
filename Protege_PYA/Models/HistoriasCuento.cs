using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Protege_PYA.Models;

public partial class HistoriasCuento
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Autor { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }

    [Url(ErrorMessage = "Por favor, ingrese una URL válida.")]
    public string? Url { get; set; }

    public string? FormatoImagen { get; set; }
}
