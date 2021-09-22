using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetSandBox.Data;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;

namespace AspNetSandBox
{
    /// <summary>Options Class.</summary>
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name
    public class Options
#pragma warning restore SA1649 // File name should match first type name
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>Gets or sets a value indicating whether this <see cref="Options" /> is verbose.</summary>
        /// <value>
        ///   <c>true</c> if verbose; otherwise, <c>false</c>.</value>
        [Option('v', "verbose", Required = false, HelpText = "Show details .")]
        public bool Verbose { get; set; }

        /// <summary>Gets or sets a value indicating whether gets or sets the connection string.</summary>
        /// <value>The connection string.</value>
        [Option('c', "connection", Required = false, HelpText = "Choose connection string for DB --c [connetionStringValue].")]
        public bool ConnectionString { get; set; }

        /// <summary>Gets or sets the connection string value.</summary>
        /// <value>The connection string value.</value>
        [Value(0, MetaName = "connectionValue", Required = false, HelpText = "Place value for connection string DB .")]
        public string ConnectionStringValue { get; set; }
    }

    /// <summary>Program Class.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Return Code int.</returns>
        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }

                       if (o.ConnectionString && o.ConnectionStringValue == null)
                       {
                           Console.WriteLine("Missing connextion string value!");
                       }
                   })
                   ;

            if (args.Length > 0)
            {
                Console.WriteLine($"There are {args.Length} args");
            }
            else
            {
                Console.WriteLine("There are no args.");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        /// <summary>Creates the host builder.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(configuration);
                });
        }
    }
}