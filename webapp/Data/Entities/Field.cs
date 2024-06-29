using System.Collections.Generic;

public class Field {
  public int? FieldId { get; set; }

  /// <value>The name of the field</value>
  public string? Name { get; set; }

  /// <value>Address of the field</value>
  public Address? Address { get; set; }

  /// <value>A list of teams that claim this as home field</value>
  public List<Team>? Teams { get; set; } = new List<Team>();

  public string? FieldImage { get; set; }
}
