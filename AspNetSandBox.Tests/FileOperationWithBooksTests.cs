using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>FileOperationWithBooksTests Class.</summary>
    public class FileOperationWithBooksTests
    {
        /// <summary>Shoulds the create file.</summary>
        [Fact]
        public void ShouldEnumerateFiles()
        {
            System.IO.DirectoryInfo directoryInfo = new (".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        /// <summary>
        /// Shoulds the create file.
        /// </summary>
        [Fact]
        public void ShouldCreateFile()
        {
#pragma warning disable SA1118 // Parameter should not span multiple lines
            File.WriteAllText("newSettings.json", @"{
                                      ""ConnectionStrings"": {
                                        ""DefaultConnection"": ""Database=d2ksfg273gcms;Host=ec2-44-194-225-27.compute-1.amazonaws.com;Port=5432;User Id=dosxxqgzjegxwt;Password=718652f7c895171b9a187f082390b5781443ea59062cf7673155f71b20276643; SSL Mode=Require; Trust Server Certificate=true"",
                                        ""HerokuConnection"": ""Database=d2ksfg273gcms;Host=ec2-44-194-225-27.compute-1.amazonaws.com;Port=5432;User Id=dosxxqgzjegxwt;Password=718652f7c895171b9a187f082390b5781443ea59062cf7673155f71b20276643; SSL Mode=Require; Trust Server Certificate=true"",
                                        ""PostgresConnection"": ""Server=127.0.0.1;Port=5432;Database=aspNetSandBox-sofia;User Id=postgres;Password=Euforie041229.;"",
                                        ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-DBSandBox-C8ECF1DE-AB43-40A2-A0B9-1892667E188C;Trusted_Connection=True;MultipleActiveResultSets=true""
                                      },
                                      ""Logging"": {
                                        ""LogLevel"": {
                                          ""Default"": ""Information"",
                                          ""Microsoft"": ""Warning"",
                                          ""Microsoft.Hosting.Lifetime"": ""Information""
                                        }
                                      },
                                      ""AllowedHosts"": ""*""
                                    }");
#pragma warning restore SA1118 // Parameter should not span multiple lines
        }

        /// <summary>
        /// Shoulds the read file.
        /// </summary>
        [Fact]
        public void ShouldReadFile()
        {
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var encodedString = temp.GetString(b);
                    Console.WriteLine(encodedString);
                }
            }
        }
    }
}
