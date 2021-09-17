using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class StartupTests
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // Assume
            string databaseUrl = "postgres://dosxxqgzjegxwt:718652f7c895171b9a187f082390b5781443ea59062cf7673155f71b20276643@ec2-44-194-225-27.compute-1.amazonaws.com:5432/d2ksfg273gcms";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            // Assert
            Assert.Equal("Database=d2ksfg273gcms;Host=ec2-44-194-225-27.compute-1.amazonaws.com;Port=5432;User Id=dosxxqgzjegxwt;Password=718652f7c895171b9a187f082390b5781443ea59062cf7673155f71b20276643; SSL Mode=Require; Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
