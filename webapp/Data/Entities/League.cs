using System.Collections.Generic;

public class League {
  public int LeagueId { get; set; }
  /// <value>The divisions of a league</value>
  public IEnumerable<Division> Divisions { get; set; } = new List<Division>();

}
