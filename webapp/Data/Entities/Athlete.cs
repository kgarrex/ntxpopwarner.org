using System;

public class Athlete {
  public int? AthleteId { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public int? TeamId { get; set; }
  public Team? Team { get; set; }
  public DateTime? Birthday { get; set; }
}

public class Coach {
  public int? CoachId { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public int? TeamId { get; set; }
}
