using System;

public class Member {
  public int MemberId { get; set; }

  /// <value>A v4 UUID used by the Authenticate system to reference a user.</value>
  public Guid AuthenticateUAC { get; set; }
}
