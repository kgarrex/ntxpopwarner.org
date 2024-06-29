using System;
using System.Collections.Generic;

public class ScheduleGenerator {
  /// <value>The number of games played by each team in a season</value>
  public int GameCount { get; set; }

  /// <value>The teams in a league</value>
  public IEnumerable<Team> Teams { get; }

  /// <value>A bitfield representing the days of the week allowed for games</value>
  public byte DaysAllowed { get; set; }

  public ScheduleGenerator(int gameCount) {
    GameCount = gameCount;
    Teams = new List<Team>();
  }

  /**
   * <summary>
   * Takes a set of rules and uses an algorithm to generate a
   * <c>Schedule</c> based on team and division data.
   * </summary>
   * <remarks>
   * The algorithm used to generate a schedule is under development.
   * </remarks>
   * <returns>
   * A <see cref="Schedule"/> object that represents the schedule.
   * </returns>
   */
  public Schedule Generate()
  {
    throw new NotImplementedException();
    var rand = new Random();
    /*
     * 1. We first need to know the number of games that are going to be played
     *    We'll use the GameCount property. If GameCount is not set then we will
     *    assume an arbitrary number of games can be played.
     *
     * 2. We then need to know the number of teams in the league.
     *    We can get this information from the count of the Teams property.
     *
     * 3. From these two pieces of information, we can determine if teams will
     *    need to play other teams multiple times in a season. Here are a few
     *    simple rules:
     *    A. If the number of games is 1/2 the number of teams, then that creates
     *       a perfectly balanced season
     */
  }
}
