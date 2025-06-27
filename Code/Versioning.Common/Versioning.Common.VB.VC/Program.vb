Imports System

Module Program
    Sub Main(args As String())

        ' Output the current version of the assembly
        Dim assembly = GetType(Program).Assembly
        Dim version = assembly.GetName().Version
        Console.WriteLine($"Current Version: {version}")
        ' Wait for user input before closing
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

    End Sub
End Module
