using System;
using System.Collections.Generic;

public class BoxScore {
  public int? BoxScoreId { get; set; }
  public short? Q1Home { get; set; }
  public short? Q1Away { get; set; }
  public short? Q2Home { get; set; }
  public short? Q2Away { get; set; }
  public short? Q3Home { get; set; }
  public short? Q3Away { get; set; }
  public short? Q4Home { get; set; }
  public short? Q4Away { get; set; }
  public short? FinalHome { get; set; }
  public short? FinalAway { get; set; }
  // Passing
  // Rushing
  // Receiving
  // Yards From Scrimmage
  // Return statistics
  // Kicking
  // Punting
  // Defensive
}

/**
 *  <summary>A single game in a season</summary>
 */
public class Game
{
  public int GameId { get; set; }
  public Team? HomeTeam { get; set; }
  public Team? AwayTeam { get; set; }
  public DateTime? Date { get; set; }

  public BoxScore BoxScore { get; set; }

  public Address? Location { get; set; }
}

public class Schedule {
  public IEnumerable<Game> Games { get; }

  public Schedule() {
    Games = new List<Game>();
  }
}
