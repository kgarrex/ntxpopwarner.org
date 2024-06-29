using System;
using System.Collections.Generic;

public class Region
{
  public int? RegionId { get; set; }
  public string? Name { get; set; }
  public List<string> States { get; set; } = new List<string>();
}
