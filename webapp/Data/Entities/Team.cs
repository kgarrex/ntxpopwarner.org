using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;


/// <summary>The format of an image</summary>
public enum ImageFormat
{ 
  /// <summary>A JPEF image</summary>
  JPEG,

  /// <summary>A PNG image</summary>
  PNG
}

public record Address(int AddressId, string Street, string City, string State, string Zip)
{}


public class Logo {
  /// <value>The image format of the logo</value>
  public ImageFormat Format { get; set; }
}


/**
 * <summary>
 * A team's name.
 * <param name="Place">Should be the city or area of a team.</param>
 * <param name="Nickname">The mascot or nickname of a team.</param>
 * </summary>
 */
public record TeamName(string Place, string Nickname){}

/**
 * <summary>
 * <param name="Email">An email address for a contact.</param>
 * <param name="Phone1">The primary phone number for a contact.</param>
 * <param name="Phone2">A secondary phone number for a contact.</param>
 * </summary>
 */
public record ContactDetails(string Email, string Phone1, string? Phone2){}


/**
 * <summary>An organization in the league</summary>
 * <remarks>Teams pay dues!</remarks>
 */
public class Team
{
  public int TeamId { get; set; }

  /// <value>The division a team falls under</value>
  public int DivisionId { get; set; }

  public List<Athlete> Players { get; set; } = new List<Athlete>();

  public int? ContactId { get; set; }

  //public ColorScheme
 
  public Team() {}

  /**
   * <summary>Create a new Team</summary>
   * <param name="name">The name of the team</param>
   * <param name="league">The league to assign the team to.</param>
   */
  public Team(string name, League league) {
  }

  /**
   * <summary>
   * Calculates the current league-wide ranking of a team based on performance.
   * </summary>
   * <returns>
   * A integer ranking within the scope of an entire league.
   * </returns>
   */
  public int GetLeagueRanking() {
    throw new NotImplementedException();
  }

  /**
   * <summary>Get the ranking a team within the scope of its division.</summary>
   * <returns>
   * An integer representing the teams ranking within a division.
   * Returns null if the team is not apart of a division.
   * </returns>
   */
  public int? GetDivisionalRanking() {
    throw new NotImplementedException();
  }

  /**
   * <summary>
   * Get the ranking a team within the scope of its conference.
   * </summary>
   * <returns>
   * An integer representing a teams ranking within a conference. 
   * Returns null if the team is not apart of a conference.
   * </returns>
   */
  public int? GetConferenceRanking() {
    throw new NotImplementedException();
  }
}


/*
public class Team
{
  public string? Place { get; set; }
  public string? Nickname { get; set; }
  [EmailAddress]
  public string? Email { get; set; }
  [DataType(DataType.PhoneNumber)]
  public string? PrimaryPhone { get; set; }
  [DataType(DataType.PhoneNumber)]
  public string? SecondaryPhone { get; set; }
  [Url]
  public string? Website { get; set; }
  public IFormFile? Logo { get; set; }
}
*/
