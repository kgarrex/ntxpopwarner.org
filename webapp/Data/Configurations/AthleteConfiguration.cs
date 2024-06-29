using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AthleteConfiguration : IEntityTypeConfiguration<Athlete> {
  public void Configure(EntityTypeBuilder<Athlete> builder) {
    builder.Property(a => a.Birthday).IsRequired();
  }
}
