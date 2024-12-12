using System;
using System.Collections.Generic;

namespace Protege_PYA.Models;

public partial class Conversacione
{
    public int Id { get; set; }

    public int? Usuario1id { get; set; }

    public int? Usuario2id { get; set; }

    public string? FechaInicio { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

    public virtual Usuario? Usuario1 { get; set; }

    public virtual Usuario? Usuario2 { get; set; }
}
