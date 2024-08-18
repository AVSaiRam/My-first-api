using System;
using System.Collections.Generic;

namespace WebApi1.Models;

public partial class Netwr
{
    public int RollNo { get; set; }

    public string Fname { get; set; } = null!;

    public string? Lname { get; set; }

    public int? Age { get; set; }
}
