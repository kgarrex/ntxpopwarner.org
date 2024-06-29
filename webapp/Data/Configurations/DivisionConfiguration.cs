using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DivisionConfiguration : IEntityTypeConfiguration<Division> {
  public void Configure(EntityTypeBuilder<Division> builder) {
    DateTime afterOn = new DateTime(2000, 8, 1);
    DateTime beforeOn = new DateTime(2000, 7, 31);
    builder.HasData(new List<Division>
    {
      new Division {
        DivisionId = 1, Name = "6U",
        AfterOn = afterOn.AddYears(17), BeforeOn = beforeOn.AddYears(19),
	MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 2, Name = "7U",
        AfterOn = afterOn.AddYears(16), BeforeOn = beforeOn.AddYears(18),
	MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 3, Name = "8U",
        AfterOn = afterOn.AddYears(15), BeforeOn = beforeOn.AddYears(17),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 4, Name = "9U",
        AfterOn = afterOn.AddYears(14), BeforeOn = beforeOn.AddYears(17),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 5, Name = "10U",
        AfterOn = afterOn.AddYears(13), BeforeOn = beforeOn.AddYears(16),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 6, Name = "11U",
        AfterOn = afterOn.AddYears(12), BeforeOn = beforeOn.AddYears(15),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 7, Name = "12U",
        AfterOn = afterOn.AddYears(11), BeforeOn = beforeOn.AddYears(14),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 8, Name = "13U",
        AfterOn = afterOn.AddYears(10), BeforeOn = beforeOn.AddYears(13),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 9, Name = "14U",
        AfterOn = afterOn.AddYears(9), BeforeOn = beforeOn.AddYears(12),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 10, Name = "Flag",
        AfterOn = afterOn.AddYears(16), BeforeOn = beforeOn.AddYears(19),
        MinWeight = null, MaxWeight = null, IsAgeOnly = true
      },
      new Division {
        DivisionId = 11, Name = "Tiny-Mite",
        AfterOn = afterOn.AddYears(16), BeforeOn = beforeOn.AddYears(19),
        MinWeight = 35, MaxWeight = 80 
      },
      new Division {
        DivisionId = 12, Name = "Mitey-Mite",
        AfterOn = afterOn.AddYears(14), BeforeOn = beforeOn.AddYears(17),
        MinWeight = 45, MaxWeight = 105 
      },
      new Division {
        DivisionId = 13, Name = "Jr. Pee Wee",
        AfterOn = afterOn.AddYears(13), BeforeOn = beforeOn.AddYears(16),
        MinWeight = 60, MaxWeight = 120
      },
      new Division {
        DivisionId = 14, Name = "Jr. Pee Wee O/L",
        AfterOn = afterOn.AddYears(12), BeforeOn = beforeOn.AddYears(13),
        MinWeight = 60, MaxWeight = 95 
      },
      new Division {
        DivisionId = 15, Name = "Pee Wee",
        AfterOn = afterOn.AddYears(12), BeforeOn = beforeOn.AddYears(15),
        MinWeight = 75, MaxWeight = 135 
      },
      new Division {
        DivisionId = 16, Name = "Pee Wee O/L",
        AfterOn = afterOn.AddYears(11), BeforeOn = beforeOn.AddYears(12),
        MinWeight = 75, MaxWeight = 110 
      },
      new Division {
        DivisionId = 17, Name = "Jr. Varsity",
        AfterOn = afterOn.AddYears(11), BeforeOn = beforeOn.AddYears(14),
        MinWeight = 90, MaxWeight = 160 
      },
      new Division {
        DivisionId = 18, Name = "Jr. Varsity O/L",
        AfterOn = afterOn.AddYears(10), BeforeOn = beforeOn.AddYears(11),
        MinWeight = 90, MaxWeight = 135
      },
      new Division {
        DivisionId = 19, Name = "Varsity",
        AfterOn = afterOn.AddYears(9), BeforeOn = beforeOn.AddYears(12),
        MinWeight = 105, MaxWeight = 185
      },
      new Division {
        DivisionId = 20, Name = "Varsity",
        AfterOn = afterOn.AddYears(8), BeforeOn = beforeOn.AddYears(9),
        MinWeight = 105, MaxWeight = 160
      },
    });
  }
}
