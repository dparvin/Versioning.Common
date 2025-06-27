// Ignore Spelling: Versioning

using System;

namespace Versioning.Common.CSharp.MS
{
    /// <summary>
    /// Represents the main entry point for the application.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Output the current version of the assembly
            var assembly = typeof(Program).Assembly;
            var version = assembly.GetName().Version;
            Console.WriteLine($"Current Version: {version}");
            // Wait for user input before closing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
