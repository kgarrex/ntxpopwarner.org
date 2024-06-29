using System.Collections.Generic;

public class Conference {
  public int? ConferenceId { get; set; }

  public int? LeagueId { get; set; }

  /// <value>The name of a conference</value>
  public string? Name { get; set; }

  /// <value>The teams of a conference</value>
  public IEnumerable<Team>? Teams { get; set; }

  public Conference(){}

  public void AddTeam(Team team) {}
  public void RemoveTeam(Team team){}
}
