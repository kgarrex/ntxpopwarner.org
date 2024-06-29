using System;

public class Division {
  public int? DivisionId { get; set; }

  /// <value>The name of an association</value>
  public string? Name { get; set; }

  public DateTime? AfterOn { get; set; }
  public DateTime? BeforeOn { get; set; }
  public int? MinWeight { get; set; }
  public int? MaxWeight { get; set; }
  public bool IsAgeOnly { get; set; } = false;

  /**
   * <summary>
   * Calculate the age level of a player based on birthday and weight
   * </summary>
   */
  public Division CalculateDivision(DateOnly dob, int weight)
  {
    // 1. Create a new DateRange using the MinDob and MaxDob
    throw new NotImplementedException();
    //divisions.Where(division => divison.Birthdays.Includes(dob));
  }
}
