using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext {
  protected readonly IConfiguration _config;
  protected readonly DbContextOptions<AppDbContext> _options;
  public DbSet<Association> Associations { get; set; }
  public DbSet<Athlete> Athletes { get; set; }
  public DbSet<Coach> Coaches { get; set; }
  public DbSet<Conference> Conferences { get; set; }
  public DbSet<Contact> Contacts { get; set; }
  public DbSet<Division> Divisions { get; set; }
  public DbSet<Field> Fields { get; set; }
  public DbSet<Game> Games { get; set; }
  public DbSet<League> Leagues { get; set; }
  public DbSet<Official> Officials { get; set; }
  public DbSet<Team> Teams { get; set; }
  public DbSet<User> Users { get; set; }
  //public DbSet<Member> Members { get; set; }


  //public AppDbContext(){}
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    _options = options;
  }

  /*
  protected override void OnConfiguring(DbContextOptionsBuilder builder){
    //builder.UseNpgsql(_config.GetConnectionString("AppDbContext"));
  }
  */

  protected override void OnModelCreating(ModelBuilder builder) {
    builder
    .ApplyConfiguration(new AthleteConfiguration())
    .ApplyConfiguration(new DivisionConfiguration());
  }
}
