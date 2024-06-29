using System.Collections.Generic;

public class Association {
  public int AssociationId { get; set; }
  public List<Team> Teams { get; set; } = new List<Team>();

  /// <value>The address of the main office of an association </value>
  public Address? OfficeAddress { get; set; }

  /// <value>The address of the playing field or court for an association</value>
  public Address? FieldAddress { get; set; }

  /// <value>The logo image for an association.</value>
  public string? LogoId { get; set; }

  /// <value>The team logo image (.png)</value>
  public string Logo { get; set; }

// <value>The team logo image (.png)</value>
  //public string Logo { get; set; }
 

  public int LeagueId { get; set; }
  

  /// <value>The user that created the team</value>
  public int UserId { get; set; }


  /// <value>The conference a team is assigned to within a league</value>
  public int ConferenceId { get; set; }

}
