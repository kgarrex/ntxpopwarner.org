using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RegionConfiguration : IEntityTypeConfiguration<Region> {
  public void Configure(EntityTypeBuilder<Region> builder) {
    builder.HasData(new List<Region>
    {
      new Region {
        RegionId = 0, Name = "Eastern Region Pop Warner"
        // NY, NJ, PA, MD, DE, DC
      },
      new Region {
        RegionId = 1, Name = "New England Region Pop Warner"
        // MA, CN, RI, NH, VT, ME
      },
      new Region {
        RegionId = 2, Name = "Mid-South Region Pop Warner"
        // AL, KY, NC, SC, TN, VA, WV
      },
      new Region {
        RegionId = 3, Name = "Southeast Region Pop Warner"
        // FL, GA, AL, MS
      },
      new Region {
        RegionId = 4, Name = "Mid-America Region Pop Warner"
        // IL, IN, IA, KS, MI, MN, MS, NE, ND, OH, SD, WS
      },
      new Region {
        RegionId = 5, Name = "Southwest Region Pop Warner"
        // AR, CO, LA, OK, NM, TX
      },
      new Region {
        RegionId = 6, Name = "Pacific Northwest Pop Warner"
        // AL, CA, NV, WA, OR, ID
      },
      new Region {
        RegionId = 7, Name = "Wescon Region Pop Warner"
        // AZ, HI, CA, NV, UT
      }
    });
  }
}
