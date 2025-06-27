Imports System
Imports System.Reflection

''' <summary>
''' This module serves as the entry point for the application.
''' It is part of the Versioning.Common.VB.MS project.
''' The project is designed to demonstrate versioning practices in VB.NET.
''' </summary>
Module Program

    ''' <summary>
    ''' Mains the specified arguments.
    ''' </summary>
    ''' <param name="args">The arguments.</param>
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
